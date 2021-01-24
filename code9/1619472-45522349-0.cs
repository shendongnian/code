    HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;
                
                try
                {
                    using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                    {
                        string reader = responseReader.ReadToEnd();
                       
                        var jsonobj = JsonConvert.DeserializeObject(reader)
                    }
                }
                catch
                {
                    return;
                }
            }
