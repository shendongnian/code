     using (WebClient client = new WebClient())
                {
                    using (Stream stream = client.OpenWrite(Input.WebRequest.RequestUri))
                    using (StreamWriter reader = new StreamWriter(stream))
                    {
                        stream.WriteTimeout = 200;
                        
                    }
                }
