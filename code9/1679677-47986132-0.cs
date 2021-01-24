    private static void ConnectToWebsite()
            {
                var proxyIP = "";
                int port;
    
                foreach (var website in WebsiteList)
                {
                    foreach (var proxy in proxyList)
                    {
                        var proxySplit = proxy.Split(':');
                        proxyIP = proxySplit[0];
                        var convert = Int32.TryParse(proxySplit[1], out port);
                        if(HttpClientExtension.GetHttpResponse(getCMYIP, proxyIP, port))
                            Console.WriteLine(website + proxy);
                    }
                }
            }
