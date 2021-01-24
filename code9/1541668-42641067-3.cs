    public class MyHttpProxy : IWebProxy
        {
               
            public MyHttpProxy()
            {
               //here you can load it from your custom config settings 
                this.ProxyUri = new Uri(proxyUri);
            }
        
            public Uri ProxyUri { get; set; }
        
            public ICredentials Credentials { get; set; }
        
            public Uri GetProxy(Uri destination)
            {
                return this.ProxyUri;
            }
        
            public bool IsBypassed(Uri host)
            {
                //you can proxy all requests or implement bypass urls based on config settings
                return false; 
              
            }
        }
    
    
    var config = new HttpClientHandler
    {
        UseProxy = true,
        Proxy = new MyHttpProxy()
    };
    
    //then you can simply pass the config to HttpClient
    var http = new HttpClient(config)
