        private string GetIPAddressRemote()
        {
            Uri validUri = new Uri("http://icanhazip.com/");
            int tryNum = 0;
            while (tryNum < 5)
            {
                tryNum++;
                try
                {
                    string externalIP = "";
                    WebProxy proxyObj = new WebProxy("http://myProxyAddress:myProxyPort/", true); // Read this from settings
                    WebRequest request = WebRequest.Create(validUri);
                    request.Proxy = proxyObj;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Timeout = 10000;  // Just to haven't an endless wait
                    using (WebResponse response = request.GetResponse())
                    {
                        Stream dataStream = response.GetResponseStream();
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            externalIP = reader.ReadToEnd();
                        }
                    }
                    return externalIP;
                }
                catch (Exception ex)
                {
                    if(tryNum > 4)
                        return ex.Message;
                }
                Thread.Sleep(1000);
            }
            return "";
        }
