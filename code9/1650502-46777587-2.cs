    var host = new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureServices(services =>
                {
                    //Setup injection
                    services.AddTransient<IExternalService>(provider =>
                    {
                        return myExtService.Object;
                    });
                })
                .UseEnvironment("IntegrationTest");
