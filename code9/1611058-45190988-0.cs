            WebRequest destRequest = WebRequest.Create(destFile);
            destRequest.Method = "PUT";
            destRequest.Headers.Add("x-ms-blob-type", "BlockBlob"); //just an example with Azure blob, doesn't matter
            using (Stream destStream = destRequest.GetRequestStream())
            {
                string sourceName = "mysourcefolder";
                //int blockSize = 8388608; //all the files have the same lenght, except one (sometimes) //all the files have the same lenght, except one (sometimes)
                for (int i = 0; i < n; i++)
                {
                    string source = sourceName + i;
                    WebRequest sourceRequest = WebRequest.Create(source);
                    destRequest.Method = "GET";
                    //HttpWebResponse destResp = (HttpWebResponse)destRequest.GetResponse();
                    //using (Stream sourceStream = destResp.GetResponseStream())
                    
                    // you need source response
                    HttpWebResponse sourceResp = (HttpWebResponse)sourceRequest.GetResponse();
                    using (Stream sourceStream = sourceResp.GetResponseStream())
                    {
                        //Guarantee buffer size
                        int blockSize = (int)sourceStream.Length;
                        sourceStream.CopyTo(destStream, blockSize);
                    }
                }
                // The request is made here
                var destinationResponse = (HttpWebResponse) destRequest.GetResponse();
                //Console.Write("ok");
                Console.Write(destinationResponse.StatusCode.ToString());
            }
