using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

// Librerias necesarias para la ejecución por hilos.
using System.Threading;
using System.Net;
using System.Net.Sockets;

// Refencias a librerias de código de este proyecto.
using AsyncTCPSocketServer;
using WebRequest;
using UDP;
using NAudioUtils;

namespace IntercomSimulator
{
    public partial class MainFormIntercomSimulator : Form
    {
        // Ficheros adicionales que no son imprescindibles pero sirven para ver la información que está llegando
        System.IO.StreamWriter fileBufferData;
        System.IO.StreamWriter fileBufferSampleValueData;

        SynchronizationContext mainContext; // Contexto del hilo principal para que los procesos asíncronos en otros hilos, puedan provocar el procesamiento y asingación de variables sobre el hilo principal.
        InterComSimulatorComponents interComSimulatorComponents;

        ThreadStart arduinoSimulatorHttpWebRequestThreadDelegate;
        Thread arduinoSimulatorHttpWebRequestThread;

        Thread phoneSimulatorListenerThread;
        ThreadStart phoneSimulatorListenerThreadDelegate;

        byte totalMaxByteValue, totalMinMaxValue;

        private int sizeOfConsumptionBuffer;
        private int sizeOfReceptionBuffer;
        private string audioReceivedData;

        public MainFormIntercomSimulator()
        {
            InitializeComponent();

            labelByteArrayAnalysis.Text = "";
            labelAudioPlayStatus.Text = "";
            labelAudioSaveStatus.Text = "";
            labelAudioCaptureStatus.Text = "";
            labelBytesPerSecond.Text = "";
            textBoxEndOfMessageTag.Text = "#EOF#";
            labelPhoneListenerOpenedConnections.Text = "";
            labelStatus.Text = "";
            textBoxListenerIPAddress.Text = MainFormIntercomSimulator.GetLocalIPAddress();
            textBoxListenerPort.Text = "8081";

            interComSimulatorComponents = new InterComSimulatorComponents(textBoxEndOfMessageTag.Text, System.Convert.ToInt32(textBoxListenerBufferSize.Text));
            interComSimulatorComponents.phoneSimulatorListener.ReceivingData += On_ReceivingData;
            interComSimulatorComponents.phoneSimulatorListener.StatusChange += On_StatusChange;
            interComSimulatorComponents.audioCapture.AudioDataAvailable += on_AudioDataAvailable;
            interComSimulatorComponents.phoneSimulatorListener.ChangeOpenedConnections += On_ChangeOpenedConnections;
            mainContext = SynchronizationContext.Current;

            initComboBoxAudioDeviceIn();
            initComboBoxAudioDeviceOut();

            comboBoxAudioDeviceIn.SelectedIndex  = 0;
            comboBoxAudioDeviceOut.SelectedIndex = 0;
            setEnabledControls();
        }

        private void on_AudioDataAvailable(byte[] _sampleBuffer, int _sampleNumOfBytes)
        {
            

            if (mainContext != null)
            {
                mainContext.Send(
                    delegate
                    {
                        //audioReceivedData = Encoding.UTF8.GetString(_sampleBuffer, 0, _sampleNumOfBytes);
                        audioReceivedData = Encoding.Default.GetString(_sampleBuffer, 0, _sampleNumOfBytes);
                        textBoxSendToPhone.Text = audioReceivedData;                        
                        labelAudioCaptureStatus.Text = String.Format("Capturando audio ... UDP {0} bytes", _sampleNumOfBytes);
                        sendDataToServer();

                    }, null);
            }

           
        }

        private void initComboBoxAudioDeviceIn()
        {
            NAudio.Wave.WaveInCapabilities[] waveInCapabilitiesList;            

            waveInCapabilitiesList = NAudioCapture.getWaveInDeviceList();
            for (int i = 0; i < waveInCapabilitiesList.Length; i++)
            {
                comboBoxAudioDeviceIn.Items.Add(waveInCapabilitiesList[i].ProductName);
            }

        }

        private void initComboBoxAudioDeviceOut()
        {
            NAudio.Wave.WaveOutCapabilities[] waveOutCapabilitiesList;

            waveOutCapabilitiesList = NAudioPlay.getWaveOutDeviceList();
            for (int i = 0; i < waveOutCapabilitiesList.Length; i++)
            {
                comboBoxAudioDeviceOut.Items.Add(waveOutCapabilitiesList[i].ProductName);
            }

        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        // Proceso que arranca el hilo de escucha del servidor del teléfono
        private void phoneSimulatorListenerStart()
        {
            interComSimulatorComponents.phoneSimulatorListener.EndOfMessageTag = textBoxEndOfMessageTag.Text;
            interComSimulatorComponents.phoneSimulatorListener.StartListening(Convert.ToInt32(textBoxListenerPort.Text), textBoxListenerIPAddress.Text, checkBoxListenerUDP.Checked);
        }

        private void buttonPhoneStartListening_Click(object sender, EventArgs e)
        {            
            sizeOfConsumptionBuffer = Convert.ToInt32(textBoxSizeOfConsumptionBuffer.Text);
            sizeOfReceptionBuffer   = Convert.ToInt32(textBoxSizeOfReceptionBuffer.Text);

            textBoxSizeOfConsumptionBuffer.Enabled = false;
            textBoxSizeOfReceptionBuffer.Enabled = false;
            checkBoxListenerUDP.Enabled = false;
            textBoxListenerBufferSize.Enabled = false;
            textBoxListenerIPAddress.Enabled = false;
            textBoxListenerPort.Enabled = false;

            interComSimulatorComponents.bufferedData = new BufferedData(sizeOfReceptionBuffer);

            //ThreadStart phoneSimulatorListenerThreadDelegate;
            // Delegado para el hilo para el servidor de escucha de conexiones entrantes del téléfono.
            //phoneSimulatorListenerThreadDelegate = new ThreadStart(phoneSimulatorListenerStart);

            // Hilo para el servidor de escucha de conexiones entrantes del teléfono
          //  Thread phoneSimulatorListenerThread = new Thread(phoneSimulatorListenerThreadDelegate);

            if (phoneSimulatorListenerThread == null)
            {
                phoneSimulatorListenerThreadDelegate = new ThreadStart(phoneSimulatorListenerStart);
                phoneSimulatorListenerThread = new Thread(phoneSimulatorListenerThreadDelegate);
            }
            else
            {
                phoneSimulatorListenerThread.Abort();
                phoneSimulatorListenerThreadDelegate = new ThreadStart(phoneSimulatorListenerStart);
                phoneSimulatorListenerThread = new Thread(phoneSimulatorListenerThreadDelegate);
            }

            phoneSimulatorListenerThread.Start();

            

            Timer.Enabled = true;
        }

        void consumeBuffer()
        {
            string receivedData;
            byte[] bufferToConsume;
            // El buffer se consume cuando el número de bytes es igual o supera a un tamaño preestablecido.
            // el número de bytes consumidos cada vez, coincide también con ese valor de umbral especificado.
            if (interComSimulatorComponents.bufferedData.BytesInBuffer > sizeOfConsumptionBuffer)
            {
                if (sizeOfConsumptionBuffer > 0)
                {
                    bufferToConsume = interComSimulatorComponents.bufferedData.getFromBuffer(sizeOfConsumptionBuffer, true);
                }
                else
                {
                    // Si el tamaño de consumo del buffer es cero, se consume todo el contenido del buffer
                    bufferToConsume = interComSimulatorComponents.bufferedData.getFromBuffer(interComSimulatorComponents.bufferedData.BytesInBuffer, true);
                }
                //receivedData = Encoding.UTF8.GetString(bufferToConsume, 0, bufferToConsume.Length);
                receivedData = Encoding.Default.GetString(bufferToConsume, 0, bufferToConsume.Length);
               
                if (interComSimulatorComponents.audioWrite.IsWritting)
                {
                    interComSimulatorComponents.audioWrite.writeBuffer(bufferToConsume, bufferToConsume.Length);
                    if (fileBufferData != null)
                    {
                        fileBufferData.WriteLine(receivedData);
                    }
                    if (fileBufferSampleValueData != null)
                    {
                        string sampleValue;
                        byte byteValue;
                        for (int i = 0; i < bufferToConsume.Length; i++)
                        {
                            byteValue = bufferToConsume[i];
                            sampleValue = byteValue.ToString();
                            fileBufferSampleValueData.WriteLine(sampleValue);
                        }
                    }
                }

                if (interComSimulatorComponents.audioPlay.IsPlaying)
                {
                    interComSimulatorComponents.bufferedWaveProvider.AddSamples(bufferToConsume, 0, bufferToConsume.Length);
                }

                byte currentMaxByte = bufferToConsume.Max<byte>();
                byte currentMinByte = bufferToConsume.Min<byte>();

                if (totalMaxByteValue < currentMaxByte)
                {
                    totalMaxByteValue = currentMaxByte;
                }
                if (totalMinMaxValue > currentMinByte)
                {
                    totalMinMaxValue = currentMinByte;
                }

                labelByteArrayAnalysis.Text = String.Format("Máximo valor: {0}({1}) Mínimo valor: {2}({3}) en buffer de captura de audio", totalMaxByteValue, currentMaxByte, totalMinMaxValue, currentMinByte);

                textBoxListenerData.Text = receivedData;
                textBoxListenerData.Refresh();
            }
        }

        void On_ReceivingData(string _receivedData, byte[] _receivedBuffer, int _receivedBytes)
        {
            if (mainContext != null)
            {
                mainContext.Send(
                    delegate
                    {                        
                        interComSimulatorComponents.bufferedData.addToBuffer(_receivedBuffer, _receivedBytes, true);
                        consumeBuffer();                        
                        
                    }, null);
            }
        }

        void On_StatusChange(string _status)
        {
            if (mainContext != null)
            {
                mainContext.Send(
                delegate
                {
                    labelStatus.Text = _status;
                    labelStatus.Refresh();
                }, null);
            }
        }

        void On_ChangeOpenedConnections(short _openedConnections)
        {
            if (mainContext != null)
            {
                mainContext.Send(
                delegate
                {
                    labelPhoneListenerOpenedConnections.Text = String.Format("{0}", _openedConnections);                    
                    labelPhoneListenerOpenedConnections.Refresh();
                }, null);
            }
        }


        private void MainFormIntercomSimulator_Load(object sender, EventArgs e)
        {
            
        }

        private string buildLocalSpeakerURL()
        {
            string ret;

            ret = String.Format("http://{0}:{1}/",textBoxListenerIPAddress.Text, textBoxListenerPort.Text );

            return ret;
        }

        private void arduinoSimulatorWebRequestStart()
        {
            if (!checkBoxSpeakerUDP.Checked)
            {
                interComSimulatorComponents.arduinoSimulatorHttpWebRequest.Url = textBoxHttpURL.Text; // "http://192.168.1.8:11000/";
                interComSimulatorComponents.arduinoSimulatorHttpWebRequest.POST(textBoxSendToPhone.Text, interComSimulatorComponents.EndOfMessageTag);
            }
            else
            {
                if (textBoxSepeakerIPAddress.Text != "" && textBoxSpeakerPort.Text != "")
                {
                    interComSimulatorComponents.UDPSocketRequest.ClientUDPConnect(textBoxSepeakerIPAddress.Text, System.Convert.ToInt32(textBoxSpeakerPort.Text));
                    if (interComSimulatorComponents.audioCapture.IsRecording)
                    {
                        interComSimulatorComponents.UDPSocketRequest.Send(audioReceivedData);
                    }
                    else
                    {
                        interComSimulatorComponents.UDPSocketRequest.Send(textBoxSendToPhone.Text);
                    }
                }
            }
        }

        private void sendDataToServer()
        {
            if (arduinoSimulatorHttpWebRequestThread == null)
            {
                arduinoSimulatorHttpWebRequestThreadDelegate = new ThreadStart(arduinoSimulatorWebRequestStart);
                arduinoSimulatorHttpWebRequestThread = new Thread(arduinoSimulatorHttpWebRequestThreadDelegate);
            }
            else
            {
                arduinoSimulatorHttpWebRequestThread.Abort();
                arduinoSimulatorHttpWebRequestThreadDelegate = new ThreadStart(arduinoSimulatorWebRequestStart);
                arduinoSimulatorHttpWebRequestThread = new Thread(arduinoSimulatorHttpWebRequestThreadDelegate);
            }

            arduinoSimulatorHttpWebRequestThread.Start();
        }

        private void buttonSendDataToPhone_Click(object sender, EventArgs e)
        {
            sendDataToServer();
            /*
            if (arduinoSimulatorHttpWebRequestThread == null)
            {
                arduinoSimulatorHttpWebRequestThreadDelegate = new ThreadStart(arduinoSimulatorWebRequestStart);
                arduinoSimulatorHttpWebRequestThread = new Thread(arduinoSimulatorHttpWebRequestThreadDelegate);
            }
            else
            {
                arduinoSimulatorHttpWebRequestThread.Abort();
                arduinoSimulatorHttpWebRequestThreadDelegate = new ThreadStart(arduinoSimulatorWebRequestStart);
                arduinoSimulatorHttpWebRequestThread = new Thread(arduinoSimulatorHttpWebRequestThreadDelegate);
            }
            
            arduinoSimulatorHttpWebRequestThread.Start();
            */
            
        }

        private void textBoxEndOfMessageTag_TextChanged(object sender, EventArgs e)
        {
            if (interComSimulatorComponents != null)
            {
                interComSimulatorComponents.EndOfMessageTag = textBoxEndOfMessageTag.Text;
            }
        }

        private void MainFormIntercomSimulator_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeListener();

            if (phoneSimulatorListenerThread != null)
            {
                phoneSimulatorListenerThread.Abort();

            }
            if (arduinoSimulatorHttpWebRequestThread != null)
            {
                arduinoSimulatorHttpWebRequestThread.Abort(); 
            }

            Application.Exit();
        }

        private void textBoxListenerPort_TextChanged(object sender, EventArgs e)
        {
            textBoxHttpURL.Text =  buildLocalSpeakerURL();
        }

        private void labelOpenedConnections_Click(object sender, EventArgs e)
        {

        }

        private void labelListener_Click(object sender, EventArgs e)
        {

        }

        private void textBoxIPAddress_TextChanged(object sender, EventArgs e)
        {
            textBoxHttpURL.Text = buildLocalSpeakerURL();
        }

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }

        private void labelPhoneListenerOpenedConnections_Click(object sender, EventArgs e)
        {

        }

        private void labelListenerStatus_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxSpeakerUDP_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledControls();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void setEnabledControls()
        {
            if (checkBoxListenerUDP.Checked)
            {
                labelPhoneListenerOpenedConnections.Visible = false;
                labelOpenedConnections.Visible = false;
            }
            else
            {
                labelPhoneListenerOpenedConnections.Visible = true;
                labelOpenedConnections.Visible = true;
            }

            if (checkBoxSpeakerUDP.Checked)
            {
                textBoxHttpURL.Text = "";
                
                textBoxSepeakerIPAddress.Enabled = true;
                textBoxSpeakerPort.Enabled = true;
                textBoxHttpURL.Enabled = false;
                textBoxEndOfMessageTag.Enabled = false;
            }
            else
            {
                textBoxSepeakerIPAddress.Text = "";
                textBoxSpeakerPort.Text = "";
                textBoxHttpURL.Text = buildLocalSpeakerURL();
                textBoxSepeakerIPAddress.Enabled = false;
                textBoxSpeakerPort.Enabled = false;
                textBoxHttpURL.Enabled = true;
                textBoxEndOfMessageTag.Enabled = true;
            }
        }

        private void checkBoxListenerUDP_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledControls();
        }

        private void closeListener()
        {
            Timer.Enabled = false;
            labelBytesPerSecond.Text = "";

            if (phoneSimulatorListenerThread != null)
            {
                interComSimulatorComponents.phoneSimulatorListener.closeListener();

                phoneSimulatorListenerThread.Abort();
                labelPhoneListenerOpenedConnections.Text = "";
                labelStatus.Text = "";
                textBoxListenerData.Text = "";
            }

            textBoxSizeOfConsumptionBuffer.Enabled = true;
            textBoxSizeOfReceptionBuffer.Enabled = true;
            checkBoxListenerUDP.Enabled = true;
            textBoxListenerBufferSize.Enabled = true;
            textBoxListenerIPAddress.Enabled = true;
            textBoxListenerPort.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            closeListener();

            /*
            Timer.Enabled = false;
            labelBytesPerSecond.Text = "";

            if (phoneSimulatorListenerThread != null)
            {
                interComSimulatorComponents.phoneSimulatorListener.closeListener();

                phoneSimulatorListenerThread.Abort();
                labelPhoneListenerOpenedConnections.Text = "";
                labelStatus.Text = "";
                textBoxListenerData.Text = "";                
            }

            textBoxSizeOfConsumptionBuffer.Enabled = true;
            textBoxSizeOfReceptionBuffer.Enabled = true;
            checkBoxListenerUDP.Enabled = true;
            textBoxListenerBufferSize.Enabled = true;
            textBoxListenerIPAddress.Enabled = true;
            textBoxListenerPort.Enabled = true;
            */
        }

        private void textBoxListenerBufferSize_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxListenerBufferSize_Validated(object sender, EventArgs e)
        {
            int bufferSize;

            if (interComSimulatorComponents.phoneSimulatorListener != null)
            {
                if (textBoxListenerBufferSize.Text != "")
                {
                    bufferSize = System.Convert.ToInt32(textBoxListenerBufferSize.Text);
                }
                else
                {
                    bufferSize = 0;
                }
                interComSimulatorComponents.phoneSimulatorListener.BufferSize = bufferSize;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelBytesPerSecond.Text = String.Format("{0} Bytes/Seg : Total Bytes recibidos {1}", interComSimulatorComponents.bufferedData.TotalBytesReceivedInLastPeriod, interComSimulatorComponents.bufferedData.TotalBytesReceived);
            interComSimulatorComponents.bufferedData.TotalBytesReceivedInLastPeriod= 0;
        }

        private void startAudioCapture()
        {
            int rate, bits, channels;
            rate        = Convert.ToInt32(textBoxAudioCaptureRate.Text);
            bits        = Convert.ToInt32(textBoxAudioCaptureBits.Text);
            channels    = Convert.ToInt32(textBoxAudioCaptureChannels.Text);

            if (comboBoxAudioDeviceIn.SelectedIndex >= 0)
            {
                interComSimulatorComponents.audioCapture.start(comboBoxAudioDeviceIn.SelectedIndex, rate, bits, channels);
                if (interComSimulatorComponents.audioCapture.IsRecording)
                {
                    labelAudioCaptureStatus.Text = "Capturando audio...";
                    audioCaptureButton.Text = "Detener captura de audio";
                    audioCaptureButton.ForeColor = Color.Red;
                }
            }
            else
            {
                labelAudioCaptureStatus.Text = "Seleccione un dispositivo de entrada de audio...";
            }
        }

        private void stopAudioCapture()
        {
            interComSimulatorComponents.audioCapture.stop();
            totalMaxByteValue = 0;
            totalMinMaxValue = 0;

            labelByteArrayAnalysis.Text = "";
            labelAudioCaptureStatus.Text = "";
            audioCaptureButton.Text = "Capturar audio";
            audioCaptureButton.ForeColor = Color.Black;
            textBoxSendToPhone.Text = "";
            textBoxSendToPhone.Refresh();
        }

        private void audioCaptureButton_Click(object sender, EventArgs e)
        {
            if (interComSimulatorComponents.audioCapture.IsRecording)
            {
                stopAudioCapture();
            }
            else
            {
                startAudioCapture();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxAudioSave_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void changeAudioSaveStatus()
        {
            int rate, bits, channels;


            if (!interComSimulatorComponents.audioWrite.IsWritting)
            {
                interComSimulatorComponents.audioWrite.stop();

                rate = Convert.ToInt32(textBoxAudioCaptureRate.Text);
                bits = Convert.ToInt32(textBoxAudioCaptureBits.Text);
                channels = Convert.ToInt32(textBoxAudioCaptureChannels.Text);

                interComSimulatorComponents.audioWrite.start(textBoxAudioFileName.Text, rate, bits, channels);

                string baseFileName = DateTime.Now.ToString("yyyyMMdd_hhmmss", CultureInfo.InvariantCulture);
                if (fileBufferData != null)
                {
                    fileBufferData.Close();
                }
                if (fileBufferSampleValueData != null)
                {
                    fileBufferSampleValueData.Close();
                }

                fileBufferData = new System.IO.StreamWriter(String.Format(textBoxAudioFileName.Text, baseFileName, "txt"));
                fileBufferSampleValueData = new System.IO.StreamWriter(String.Format(textBoxAudioFileName.Text, baseFileName, "csv"));

                labelAudioSaveStatus.Text = "Grabando audio...";
                buttonAudioSave.Text = "Detener grabación";
                buttonAudioSave.ForeColor = Color.Red;

                string saveAudioTime = textBoxSaveAudioTime.Text;
                int intervalAudioSaveTimer = Convert.ToInt32(saveAudioTime);
                if (intervalAudioSaveTimer != 0)
                {
                    timerAudioSaveSeconds.Interval = intervalAudioSaveTimer;
                    timerAudioSaveSeconds.Enabled = true;
                }
            }
            else
            {

                interComSimulatorComponents.audioWrite.stop();
                if (fileBufferData != null)
                {
                    fileBufferData.Close();
                }
                if (fileBufferSampleValueData != null)
                {
                    fileBufferSampleValueData.Close();
                }

                labelAudioSaveStatus.Text = "";
                buttonAudioSave.ForeColor = Color.Black;
                buttonAudioSave.Text = "Grabar Audio";

            }

        }

        private void buttonAudioSave_Click(object sender, EventArgs e)
        {
            changeAudioSaveStatus();
            /*
            int rate, bits, channels;


            if (!interComSimulatorComponents.audioWrite.IsWritting)
            {
                interComSimulatorComponents.audioWrite.stop();

                rate = Convert.ToInt32(textBoxAudioCaptureRate.Text);
                bits = Convert.ToInt32(textBoxAudioCaptureBits.Text);
                channels = Convert.ToInt32(textBoxAudioCaptureChannels.Text);

                interComSimulatorComponents.audioWrite.start(textBoxAudioFileName.Text, rate, bits, channels);

                string baseFileName = DateTime.Now.ToString("yyyyMMdd_hhmmss", CultureInfo.InvariantCulture);
                if (fileBufferData != null)
                {
                    fileBufferData.Close();
                }
                if (fileBufferSampleValueData != null)
                {
                    fileBufferSampleValueData.Close();
                }

                fileBufferData = new System.IO.StreamWriter(String.Format(textBoxAudioFileName.Text, baseFileName, "txt"));
                fileBufferSampleValueData = new System.IO.StreamWriter(String.Format(textBoxAudioFileName.Text, baseFileName, "csv"));

                labelAudioSaveStatus.Text = "Grabando audio...";
                buttonAudioSave.Text = "Detener grabación";
                buttonAudioSave.ForeColor = Color.Red;
            }
            else
            {                
                
                interComSimulatorComponents.audioWrite.stop();
                if (fileBufferData != null)
                {
                    fileBufferData.Close();
                }
                if (fileBufferSampleValueData != null)
                {
                    fileBufferSampleValueData.Close();
                }

                labelAudioSaveStatus.Text = "";
                buttonAudioSave.ForeColor = Color.Black;
                buttonAudioSave.Text = "Grabar Audio";
                
            }
            */
        }

        private void buttonAudioPlay_Click(object sender, EventArgs e)
        {
            int rate, bits, channels;
            
            if (interComSimulatorComponents.audioPlay.IsPlaying)
            {
                interComSimulatorComponents.audioPlay.stop();                    
                buttonAudioPlay.Text = "Reproducir audio";
                buttonAudioPlay.ForeColor = Color.Black;
                labelAudioPlayStatus.Text = "";
            }
            else
            {
                if (comboBoxAudioDeviceOut.SelectedIndex >= 0)
                {
                    rate = Convert.ToInt32(textBoxAudioCaptureRate.Text);
                    bits = Convert.ToInt32(textBoxAudioCaptureBits.Text);
                    channels = Convert.ToInt32(textBoxAudioCaptureChannels.Text);

                    interComSimulatorComponents.bufferedWaveProvider = interComSimulatorComponents.audioPlay.start(rate, bits, channels);
                    labelAudioPlayStatus.Text = "Reproduciendo audio";
                    buttonAudioPlay.Text = "Detener Reproducción audio";
                    buttonAudioPlay.ForeColor = Color.Red;
                }
                else
                {
                    labelAudioPlayStatus.Text = "Seleccione un dispositivo de salida...";
                }
            }
        }

        private void timerAudioSaveSeconds_Tick(object sender, EventArgs e)
        {
            timerAudioSaveSeconds.Enabled = false;
            changeAudioSaveStatus();
        }
    }

    class InterComSimulatorComponents
    {
        private string endOfMessageTag;
        public AsyncTCPServer phoneSimulatorListener; // Simulador del servidor que estaría en el teléfono a la escucha de las conexiones entrantes.
        public AsyncTCPServer arduinoSimulatorComListener; // Simulador del servidor que estaría en Arduino a la escucha de las conexiones entrantes.
        public httpWebRequest arduinoSimulatorHttpWebRequest; // Simulador de envío de datos a un servidor mediante protocolo http.
        public UDPSocket UDPSocketRequest; // Simulador de envío de datos a un servidor mediante protocolo de transporte UDP
        public BufferedData bufferedData; // Manejador del buffer donde irán llegando los datos que se reciban en el proceso que está a la escucha en un puerto UDP.
        public NAudioCapture audioCapture; // Clase para la captura de audio desde un dispositivo.
        public NAudioWrite audioWrite; // Clase que graba el audio recibido en un fichero.
        public NAudio.Wave.BufferedWaveProvider bufferedWaveProvider;
        public NAudioPlay audioPlay; // Clase que reproduce el sonido que se ha recibido sobre algún dispositivo de salida.



        private string _httpWebRequestUri;

        public string httpWebRequestUri
        {
            get { return _httpWebRequestUri; }
            set { _httpWebRequestUri = value; }
        }

        public string EndOfMessageTag
        {
            get { return endOfMessageTag; }
            set { endOfMessageTag = value; }
        }

        public InterComSimulatorComponents(string _endOfMessageTag, int _bufferSize)
        {
            EndOfMessageTag = _endOfMessageTag;


            phoneSimulatorListener = new AsyncTCPServer(endOfMessageTag, _bufferSize);
            arduinoSimulatorHttpWebRequest = new httpWebRequest();
            UDPSocketRequest = new UDPSocket();
            audioCapture = new NAudioCapture();
            audioWrite = new NAudioWrite();
            audioPlay = new NAudioPlay();
        }

        ~InterComSimulatorComponents()
        {
            
        }
    }  
  
    class BufferedData
    {
        private byte[] buffer;
        private int sizeofBuffer;
        private int bytesInBuffer;
        private long totalBytesReceived;
        private long totalBytesReceivedInLastPeriod;

        public int SizeOfBuffer
        {
            get {return sizeofBuffer;}
            set {sizeofBuffer = value;}
        }

        public int BytesInBuffer
        {
            get {return bytesInBuffer;}
            set {bytesInBuffer = value;}
        }

        public long TotalBytesReceived
        {
            get { return totalBytesReceived; }
            set { totalBytesReceived = value; }
        }

        public long TotalBytesReceivedInLastPeriod
        {
            get { return totalBytesReceivedInLastPeriod; }
            set { totalBytesReceivedInLastPeriod = value; }
        }

 
        public void addToBuffer(Byte[] _buffer, int _numOfBytes, Boolean _sumTotalBytesReceived = true)
        {
            int bytesToAdd = _numOfBytes;
            int bytesFree  = sizeofBuffer - bytesInBuffer;
            if (bytesToAdd > bytesFree)
            {
                bytesToAdd = bytesFree;
            }
            if (bytesToAdd > 0)
            {
                Array.Copy(_buffer, 0, buffer, bytesInBuffer, bytesToAdd);
                bytesInBuffer       += bytesToAdd;
                if (_sumTotalBytesReceived)
                {
                    totalBytesReceived             += bytesToAdd;
                    totalBytesReceivedInLastPeriod += bytesToAdd;
                }
            }
        }

        // Obtiene el numero de bytes indicado desde el buffer de origen. Si _clearSourceBuffer = true, entonces los datos devueltos
        // son eliminados del buffer original, desplazando aquellos datos que queden hacia la izquierda donde quedarán ubicados desde la posicion 0
        public byte[] getFromBuffer(int _numOfBytes, Boolean _clearSourceBuffer)
        {
            byte[] ret;

            if (_numOfBytes > bytesInBuffer)
            {
                _numOfBytes = bytesInBuffer;
            }

            ret = new byte[_numOfBytes];
            if (_numOfBytes > 0)
            {
                Array.Copy(buffer, ret, _numOfBytes);
                if (_clearSourceBuffer)
                {
                    int bytesToPreserve = bytesInBuffer - _numOfBytes;
                    Array.Copy(buffer, _numOfBytes, buffer, 0, bytesToPreserve);
                    Array.Clear(buffer, bytesToPreserve, bytesInBuffer - bytesToPreserve);


                    bytesInBuffer = bytesToPreserve;
                }
            }

            return ret;
        }

        public BufferedData (int _sizeOfBuffer)
        {
            sizeofBuffer = _sizeOfBuffer;
            buffer = new byte[sizeofBuffer];
        }

        ~BufferedData ()
        {
            
        }
    }
}
