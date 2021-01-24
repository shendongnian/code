    _server = new TestServer(new WebHostBuilder()
        .UseStartup<Startup>()
        .ConfigureServices(services =>
            {
                services.AddSingleton(new DbSettings(...));
            }
        );
        
