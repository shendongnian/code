        static AttributesBaseController 
        {
            Client = new HttpClient(new HttpClientHandler { Proxy = null, UseProxy = false })
            {
                Timeout = TimeSpan.FromSeconds(double.Parse(WebConfigurationManager.AppSettings["httpTimeout"]))
            };
    
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
