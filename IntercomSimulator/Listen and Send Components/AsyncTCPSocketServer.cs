using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Librerias necesarias para el servidor de escucha asíncrono
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace AsyncTCPSocketServer
{
    
    // State object for reading client data asynchronously  
    public class StateObject
    {
        // Client  socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
  //      public const int BufferSize = 1024;
        public int BufferSize;
        // Receive buffer.  
        public byte[] buffer;// = new byte[1024];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();

        public StateObject(int _bufferSize)
        {
            BufferSize = _bufferSize;
            buffer = new byte[_bufferSize];
        }
    }

    public class UDPState
    {
        public int BufferSize;
        public byte[] buffer;

        public UDPState(int _bufferSize)
        {
            BufferSize = _bufferSize;
            buffer = new byte[BufferSize];
        }
    }

    // Servidor que queda a la escucha de conexiones a través de un Socket TCP en un puerto e IP determinados 
    class AsyncTCPServer
    {
        private string endOfMessageTag; // Indica si existe una marca de final de mensaje que el servidor tenga que considerar para saber que ya se han enviado todos los datos, y por tanto puede terminar la comunicación.
        private string currentStatus; // Texto que indica el estado actual del servidor que está a la escucha.
        private short openedConnections; // Número de conexiones que se encuentan abiertas en este momento. 

        public delegate void changeOpenedConnections(short _openedConnections); // Delegado para disparar un evento cada vez que se produzcan cambios en el número de conexiones abiertas.
        public event changeOpenedConnections ChangeOpenedConnections;

        public delegate void receivingData(string _receivedData, byte[] _receivedBuffer, int _receivedBytes); // publicamos un delegado para crear posteriormente un evento para el momento en el que se reciban los datos
        public event receivingData ReceivingData;

        public delegate void statusChange(string _status);
        public event statusChange StatusChange;

        private UDPState UDPState; // UDPState = new UDPState();
        private int bufferSize;

        

        Socket UDPListenerSocket;

        public string EndOfMessageTag
        {
            get { return endOfMessageTag; }
            set { endOfMessageTag = value; }
        }


        public int BufferSize
        {
            get { return bufferSize; }
            set {                    
                    bufferSize = value;
                    UDPState = new UDPState(bufferSize);  
                }        
        }



        // Thread signal.  
        public ManualResetEvent allDone = new ManualResetEvent(false);

        public AsyncTCPServer(string _endOfMessageTag = "", int _bufferSize = 1024)
        {
            bufferSize = _bufferSize;
            currentStatus = "";            
            endOfMessageTag = _endOfMessageTag;
            UDPState = new UDPState(bufferSize);
            allDone = new ManualResetEvent(false); // Se crea una instancia para el bloqueador manual de procesos en paralelo
        }

        ~AsyncTCPServer()
        {
            
                        
        }

        private short OpenedConnections
        {
            get { return openedConnections; }
            set
            {
                openedConnections = value;
                ChangeOpenedConnections(openedConnections);
            }
        }

        public string CurrentStatus
        {
            get { return currentStatus; }
            set { currentStatus = value; }
        }

        IPAddress getIPAddress(string _IPAddress)
        {
            IPAddress ret = null;

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ipAddress in ipHostInfo.AddressList)
            {
                if (ipAddress.ToString() == _IPAddress)
                {
                    ret = ipAddress;
                }            
            }

            if (ret == null)
            {
                throw new Exception(String.Format("La dirección IP {0} no es válida"));
            }

            return ret;
        }        

        public void StartListening(int _port, string _IPAddress, Boolean _udp)
        {
            IPAddress ipAddress;
            Socket listener;

            // Establish the local endpoint for the socket.  
            // The DNS name of the computer  
            // running the listener is "host.contoso.com".  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            ipAddress = getIPAddress(_IPAddress);             
                

           //  IPAddress ipAddress = ipHostInfo.AddressList[3];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, _port);

            if (!_udp)
            {
                // Create a TCP/IP socket.  
                listener = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
            }
            else
            {
                // Create a UDP socket.  
                listener = new Socket(ipAddress.AddressFamily,
                    SocketType.Dgram, ProtocolType.Udp);
                listener.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            }

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                if (!_udp)
                {
                    
                    listener.Listen(100);


                    OpenedConnections = 0;

                    while (true)
                    {
                        // Set the event to nonsignaled state.  
                        allDone.Reset();

                        // Start an asynchronous socket to listen for connections.  
                        CurrentStatus = "Esperando una conexión...";
                        StatusChange(currentStatus);


                        listener.BeginAccept(
                           this.AcceptCallback,
                            listener);

                        // Wait until a connection is made before continuing.  
                        allDone.WaitOne();


                    }
                }
                else
                {
                    int bufSize = bufferSize;
                    listener.ReceiveBufferSize = bufferSize;
                    EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
                    AsyncCallback recv = null;
                    listener.BeginReceiveFrom(UDPState.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
                    {
                        UDPState so = (UDPState)ar.AsyncState;
                        try
                        {
                            int bytes = listener.EndReceiveFrom(ar, ref epFrom);
                            //string content = Encoding.UTF8.GetString(so.buffer, 0, bytes);
                            string content = Encoding.Default.GetString(so.buffer, 0, bytes);
                            ReceivingData(content, so.buffer, bytes);
                            listener.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);
                            //      Console.WriteLine("RECV: {0}: {1}, {2}", epFrom.ToString(), bytes, Encoding.ASCII.GetString(so.buffer, 0, bytes));
                            CurrentStatus = string.Format("Recibidos {0} bytes...", bytes);
                            StatusChange(currentStatus);
                        }
                        catch (System.ObjectDisposedException)
                        {
                        }
                        catch (System.Net.Sockets.SocketException e)
                        {
                            CurrentStatus = e.ToString();
                            StatusChange(currentStatus);
                        }
                        
                    }, UDPState);

                    // Start an asynchronous socket to listen for connections.  
                    CurrentStatus = "Esperando una conexión...";
                    StatusChange(currentStatus);
                    UDPListenerSocket = listener;
                }
            }
            catch (Exception e)
            {
                currentStatus = e.ToString();
                StatusChange(currentStatus);
            }
        }

        public void closeListener()
        {
            if (UDPListenerSocket != null)
            {                
                UDPListenerSocket.Close();
                UDPListenerSocket.Dispose();
                UDPListenerSocket = null;
            }

        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            allDone.Set();

            CurrentStatus = "Conexión entrante aceptada";
            StatusChange(currentStatus);

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.  
            StateObject state = new StateObject(bufferSize);
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, bufferSize/*StateObject.BufferSize*/, 0,
                this.ReadCallback, state);

            OpenedConnections = (short)(OpenedConnections + 1);
        }

        Boolean NoMoretDataToReceive(string _data)
        {
            Boolean ret = false;

            if (endOfMessageTag != "" && _data.IndexOf(endOfMessageTag) > -1)
            {
                ret = true;
            }

            return ret;
        }

        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            CurrentStatus = "Recibiendo datos...";
            StatusChange(currentStatus);

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.  
                state.sb.Append(Encoding.UTF8.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read   
                // more data.  
                content = state.sb.ToString();
                ReceivingData(content, state.buffer, bytesRead); // Llamamos al evento que se dispara cuando se reciben datos
                if (NoMoretDataToReceive(content))
                {
                    // All the data has been read from the   
                    // client. Display it on the console.  
                    CurrentStatus = String.Format("{0} bytes Leídos desde el socket. Datos leídos : {1}", content.Length, content);
                    StatusChange(currentStatus);
                    // Echo the data back to the client.
                    //string response = @"HTTP/1.1 200 OK\r\nServer: WAS/6.0\r\nContent-Length: 0\r\n\\r\n\\r\n\";
                    string response = "HTTP/1.1 200 OK\r\nServer: INTERCOMUNICATOR\r\nContent-Type: text/html; charset=utf-8\r\n\r\n\r\n";
                    
                    this.Send(handler, response);
                }
                else
                {
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, bufferSize/*StateObject.BufferSize*/, 0,
                    this.ReadCallback, state);
                }
            }
            else
            {
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                OpenedConnections = (short)(OpenedConnections - 1);
            }
        }

        private void Send(Socket handler, String data)
        {
            CurrentStatus = "Enviando datos...";
            StatusChange(currentStatus);

            // Convert the string data to byte data using UTF8 encoding.  
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            // Begin sending the data to the remote device.  
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                this.SendCallback, handler);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                CurrentStatus = String.Format("{0} bytes enviados al cliente", bytesSent);
                StatusChange(CurrentStatus);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                OpenedConnections = (short)(OpenedConnections - 1);                
            }
            catch (Exception e)
            {
                CurrentStatus = e.ToString();
            }
        }
    }
}