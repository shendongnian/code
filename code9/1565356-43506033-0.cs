    public static HttpClient GetInMemoryServerClient(HttpConfiguration serverConfig = null) {
        var config = serverConfig ?? new HttpConfiguration();
        MyService.WebApiConfig.Register(config, isTest: true);
        var server = new HttpServer(config); //<-- pass config to server        
        var client = new HttpClient(server);
        //Server defaults to localhost so setting client to localhost as well
        client.BaseAddress = new Uri("http://localhost"); 
        return client;
    }
