    private JObject PostingToPKFAndDecompress(string sData, string sUrl)
            {
                var jOBj = new JObject();
                try
                {
    
                    try
                    {
                        string urlStr = @"" + sUrl + "?param=" + sData;
    
    
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlStr);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream resStream = response.GetResponseStream();
    
                        var t = ReadFully(resStream);
                        var y = Decompress(t);
    
                        using (var ms = new MemoryStream(y))
                        using (var streamReader = new StreamReader(ms))
                        using (var jsonReader = new JsonTextReader(streamReader))
                        {
                            jOBj = (JObject)JToken.ReadFrom(jsonReader);
                        }
    
    
                    }
                    catch (System.Net.Sockets.SocketException)
                    {
                        // The remote site is currently down. Try again next time. 
                    }
    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                return jOBj;
            }
    
            public static byte[] ReadFully(Stream input)
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            }
    
            public static byte[] Decompress(byte[] data)
            {
                using (var compressedStream = new MemoryStream(data))
                using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                using (var resultStream = new MemoryStream())
                {
                    zipStream.CopyTo(resultStream);
                    return resultStream.ToArray();
                }
            }
