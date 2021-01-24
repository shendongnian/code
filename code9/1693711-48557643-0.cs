    protected string RemoteApiCallPOST(JObject elements, string url)
            {
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    // JObject jsonResult = new JObject();
                    string id;
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(elements);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
    
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        id = (streamReader.ReadToEnd()).ToString();
    
                        return id;
                    }
                }
                catch (Exception EX)
                {
                    return "";
                }
            }
