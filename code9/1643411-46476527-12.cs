    var factory = new HttpClientFactory();
    factory.Register("ClientA", new HttpClient());
    factory.Register("ClientB", new HttpClient());
    container.AddSingleton<IHttpClientFactory>(factory);
    
