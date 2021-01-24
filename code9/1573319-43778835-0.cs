    var webRequest = WebRequest.Create(url) as HttpWebRequest;
                if (webRequest != null)
                {
                    webRequest.Accept = "*/*";
                    webRequest.UserAgent = ".NET";
                    webRequest.Method = WebRequestMethods.Http.Post;
                    webRequest.ContentType = "application/json";
                    webRequest.Host = "coinbase.com";
    
                    var whc = new WebHeaderCollection
                    {
                        "ACCESS_KEY: " + API_KEY,
                        "ACCESS_SIGNATURE: " + signature,
                        "ACCESS_NONCE: " + nonce
                    };
                    webRequest.Headers = whc;
    
                    using (WebResponse response = webRequest.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream);
                            returnData = reader.ReadToEnd();
                        }
                    }
                }
