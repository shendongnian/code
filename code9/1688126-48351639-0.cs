      private string ProcessSpeechStream(Stream stream)
            {
             
                var ms = new MemoryStream();
                stream.CopyTo(ms);
                var arr = ms.ToArray();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.wit.ai/speech");
                request.SendChunked = true;
                request.Method = "POST";
                request.Headers["Authorization"] = "Bearer " + APIToken;
                request.ContentType = "audio/raw;encoding=signed-integer;bits=16;rate=44100;endian=little";
                request.ContentLength = arr.Length;
                var st = request.GetRequestStream();
                st.Write(arr, 0, arr.Length);
                st.Close();
                // Process the wit.ai response
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader response_stream = new StreamReader(response.GetResponseStream());
                        return response_stream.ReadToEnd();
                    }
                    else
                    {
                        Logger.AILogger.Log("Error: " + response.StatusCode.ToString());
                        return string.Empty;
    
                    }
                }
                catch (Exception ex)
                {
                    Logger.AILogger.Log("Error: " + ex.Message, ex);
                    return string.Empty;
                }
            }
