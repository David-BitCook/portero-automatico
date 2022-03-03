using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NAudioUtils
{
    /*
    string saveLocation = @"c:\PruebasDeSonido\CapturaDeMicrofono.wav";


            NAudio.Wave.WaveInEvent waveIn = new NAudio.Wave.WaveInEvent();
            //waveIn.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.DeviceNumber = 0; // Se asigna el dispositivo de entrada del audio
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(8000, 8, 1);
            waveWriter = new NAudio.Wave.WaveFileWriter(saveLocation, waveIn.WaveFormat);

            waveBuffer = new NAudio.Wave.BufferedWaveProvider(waveIn.WaveFormat); // initializes buffer
            waveBuffer.DiscardOnBufferOverflow = true;

            waveIn.StartRecording();
            System.Threading.Thread.Sleep(10000); // Grabamos 10 segundos
            waveIn.StopRecording();

            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }

            if (waveIn != null)
            {
                waveIn.Dispose();
                waveIn = null;
            }
            Environment.Exit(0);  // Se cierra el programa de cónsola
    */

    // Clase que prepara la captura de audio desde un dispositivo, ya sea un micrófono o un archivo de audio .wmv
    class NAudioCapture
    {
        private NAudio.Wave.WaveInEvent waveIn;
        private Boolean isRecording;

        // Se declara un evento que se disparará cuando el dispositivo tenga datos de muestra de audio disponibles.
        public delegate void audioDataAvailable(byte[] _sampleBuffer, int _sampleNumOfBytes);
        public event audioDataAvailable AudioDataAvailable;

        public Boolean IsRecording
        {
            get { return isRecording; }         
        }

        public NAudioCapture()
        {            
            isRecording = false;            
            AudioDataAvailable += on_AudioDataAvailable; // Se asocia al menos un subscriptor al evento, de forma que si nadie más se suscribe, no pete el programa.
        }

        // Método que se dispara automáticamente cuando el sistema nos va enviando el muestreo que realiza desde el dispositivo de entrada de Audio
        void waveIn_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {            
            // Se llama a un evento con los datos de muestreo que acaban de llegar desde el dispositivo de audio
            AudioDataAvailable(e.Buffer, e.BytesRecorded);
        }

        private void on_AudioDataAvailable(byte[] _sampleBuffer, int _sampleNumOfBytes)
        {
            /*
            if (audioWrite != null)
            {
                string receivedData = Encoding.Default.GetString(_sampleBuffer, 0, _sampleNumOfBytes);                
                

                byte[] prueba = Encoding.Default.GetBytes(receivedData);
                audioWrite.writeBuffer(prueba, prueba.Length);
                //audioWrite.writeBuffer(_sampleBuffer, _sampleNumOfBytes);
            }
             */ 
        }

        public static NAudio.Wave.WaveInCapabilities[] getWaveInDeviceList()
        {            
            NAudio.Wave.WaveInCapabilities[] ret = {}; // Se inicializa un array vacío.
            
            NAudio.Wave.WaveInEvent waveIn = new NAudio.Wave.WaveInEvent();
            int deviceCount = NAudio.Wave.WaveIn.DeviceCount; // Contiene el número de dispsitivos de entrada disponibles en el sistema.
            NAudio.Wave.WaveInCapabilities waveInCapabilities; // Estructura que contiene la información de un dispositivo de entrada.

            if (deviceCount > 0)
            {
                ret = new NAudio.Wave.WaveInCapabilities[deviceCount];
                for (int i = 0; i < deviceCount; i++)
                {
                    waveInCapabilities = NAudio.Wave.WaveIn.GetCapabilities(i);
                    ret[i] = waveInCapabilities;
                }
            }

            waveIn.Dispose();
        
            return ret;
        }

        // Comienza la captura de audio desde el disositivo indicado por parámetro.
        // _rate se corresponde con la frecuencia de muestreo.
        // _bits se corresponde con el número de bits con los que se quiere que capture cada muestra (más bits más precisión)
        // _channels indica si se quiere capturar en mono (1) o en estéreo (2)
        public void start(int _deviceNumber, int _rate, int _bits, int _channels)
        {
            if (waveIn != null)
            {
                waveIn.Dispose();
            }

            waveIn  = new NAudio.Wave.WaveInEvent();
            waveIn.DataAvailable            += waveIn_DataAvailable;
            waveIn.DeviceNumber             = _deviceNumber;
            waveIn.WaveFormat               = new NAudio.Wave.WaveFormat(_rate, _bits, _channels);            

            // Comienza el muestreo de audio
            isRecording = true;
            waveIn.StartRecording();
            
        }

        // Para el muestreo de audio que se está ejecutando en este momento.
        public void stop()
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
                waveIn.Dispose();
            }
                        
            
            isRecording = false;
        }
    }

    class NAudioWrite
    {
        private NAudio.Wave.WaveFileWriter waveWriter;
        private Boolean isWritting;
        private string fileName;


        public Boolean IsWritting
        {
            get { return isWritting; }
        }

        public NAudioWrite()
        {
            isWritting = false;
        }

        public void start(string _fileName, int _rate, int _bits, int _channels)
        {

            fileName = String.Format(_fileName, DateTime.Now.ToString("yyyyMMdd_hhmmss", CultureInfo.InvariantCulture), "wav");
            
            waveWriter = new NAudio.Wave.WaveFileWriter(fileName, new NAudio.Wave.WaveFormat(_rate, _bits, _channels));
            isWritting = true;
        }

        public void writeBuffer(byte[] _buffer, int _numOfBytes)
        {
            if (waveWriter != null)
            {
                waveWriter.Write(_buffer, 0, _numOfBytes);
                waveWriter.Flush();
            }
        }

        public void stop()
        {
            if (waveWriter != null)
            {
                waveWriter.Close();
                waveWriter.Dispose();
            }

            isWritting = false;
        }
    }

    class NAudioPlay
    {
        private NAudio.Wave.WaveOut waveOut;
        private Boolean isPlaying;

        public Boolean IsPlaying
        {
            get { return isPlaying; }
        }

        public static NAudio.Wave.WaveOutCapabilities[] getWaveOutDeviceList()
        {
            NAudio.Wave.WaveOutCapabilities[] ret = { }; // Se inicializa un array vacío.

            NAudio.Wave.WaveOutEvent waveOut = new NAudio.Wave.WaveOutEvent();
            int deviceCount = NAudio.Wave.WaveOut.DeviceCount; // Contiene el número de dispsitivos de Salida disponibles en el sistema.
            NAudio.Wave.WaveOutCapabilities waveOutCapabilities; // Estructura que contiene la información de un dispositivo de salida.

            if (deviceCount > 0)
            {
                ret = new NAudio.Wave.WaveOutCapabilities[deviceCount];
                for (int i = 0; i < deviceCount; i++)
                {
                    waveOutCapabilities = NAudio.Wave.WaveOut.GetCapabilities(i);
                    ret[i] = waveOutCapabilities;
                }
            }

            waveOut.Dispose();

            return ret;
        }

        public NAudioPlay()
        {
            isPlaying = false;

        }

        public NAudio.Wave.BufferedWaveProvider start(int _rate, int _bits, int _channels)
        {
            NAudio.Wave.BufferedWaveProvider bwp;
            waveOut = new NAudio.Wave.WaveOut();

            bwp = new NAudio.Wave.BufferedWaveProvider(new NAudio.Wave.WaveFormat(_rate, _bits, _channels));
            bwp.DiscardOnBufferOverflow = true;

            waveOut.Init(bwp);
            waveOut.Play();

            isPlaying = true;

            return bwp;
        }

        public void stop()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();                
            }

            isPlaying = false;
        }
    }
}
