                    var uri = new Uri(string.Format(_host + url, string.Empty));
                    var webRequest2 = (HttpWebRequest)WebRequest.Create(uri);
    
    
                    webRequest2.Headers.Add("Cookie",
                        GlobalConfig.SessionId);
                    webRequest2.Headers.Add("_RequestVerificationToken", GlobalConfig.Token);
                    webRequest2.Method = "POST";
                    webRequest2.ContentType = "application/xml";
    
                    byte[] bytes = Encoding.UTF8.GetBytes(body);
                    webRequest2.ContentLength = bytes.Length;
                    StreamWriter writer = new StreamWriter(webRequest2.GetRequestStream());
                    writer.Write(bytes);
                    webResponse = webRequest2.GetResponse();
