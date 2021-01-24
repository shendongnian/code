    using System;
    using System.IO;
    using System.Net;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create a request for the URL.   
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                  "http://www.contoso.com/default.html");
                // If required by the server, set the credentials.  
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.  
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                
                // Get the stream containing content returned by the server.  
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
                // Clean up the streams and the response.  
                reader.Close();
                response.Close();
            }
        }
    }
