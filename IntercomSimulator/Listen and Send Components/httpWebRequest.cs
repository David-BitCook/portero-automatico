using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace WebRequest
{
    // Clase cuyo propósito es el envío  y solicitud de información a través del protocolo http
    class httpWebRequest
    {
        private string url;
        

        public delegate void POSTstatusDescription(string _POSTStatusDescription);
        public event POSTstatusDescription POSTStatusDescriptionChange;

        public string Url
        {
            get {return url;}
            set
            {
                if (url != value)
                {
                    url = value;
                    
                }
            }
        }

        void httpRequest()
        {

        }

        // Envía una cadena de datos mediante una llamada POST del protcolo http
        public string POST(string _postData, string _endOfMessageTag = "", string _contentType = "application/x-www-form-urlencoded")
        {
            System.Net.HttpWebRequest request;
            string responseFromServer = "";

            if (_endOfMessageTag != "")
            {
                _postData = _postData + _endOfMessageTag;
            }

            // Se crea el objeto que va a hacer la petición
            request = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);

            // Set the Method property of the request to POST.  
            request.Method = "POST";

            // Create POST data and convert it to a byte array.  
            string postData = _postData;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.  
            request.ContentType = _contentType;
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;

            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();
            
            // Get the response.
            
   //         WebResponse response = request.GetResponse();
            // Display the status.  
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
  //          POSTStatusDescriptionChange(((HttpWebResponse)response).StatusDescription);


            // Get the stream containing content returned by the server.  
            // The using block ensures the stream is automatically closed.
  /*          using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                responseFromServer = reader.ReadToEnd();                
            }
            */
            // Close the response.  
   //         response.Close();            

           // POSTStatusDescriptionChange("");
            
            return responseFromServer;
        }
    }
}
