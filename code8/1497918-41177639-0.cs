    String MyURI = "[REST API URL]";
                WebRequest WReq = WebRequest.Create(MyURI);
                WReq.Credentials =
                    new NetworkCredential("[user name]", "[password]", "[domain]");
    
                WebResponse response = WReq.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
