            internal IAsyncResult RequestGet<TPostType>(Action<string> callback, string path, TPostType value)
        {
            var http = (HttpWebRequest)WebRequest.Create(Connection.GetUri(path).Uri);
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            var parsedContent = JsonConvert.SerializeObject(value);
            var encoding = new ASCIIEncoding();
            var bytes = encoding.GetBytes(parsedContent);
            return http.BeginGetRequestStream(ar => {
                try
                {
                    var stream = http.EndGetRequestStream(ar);  
                    stream.Write(bytes, 0, bytes.Length);
                    
                    stream.Close();
                    var response = http.GetResponse();
                    var responseStream = response.GetResponseStream();
                    ReadStream(callback, responseStream);
                }
                catch (WebException webex)
                {
                    WebResponse errResp = webex.Response;
                    using (Stream respStream = errResp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream);
                        string text = reader.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
            }, null);
        }
