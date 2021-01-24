            var host = new WebHostBuilder()
                .ConfigureServicesTest(services =>
                {
                    //Setup injection
                    services.AddTransient<IInternalService>(provider =>
                    {
                        return myExtService.Object;
                    });
                });
            var server = new TestServer(host);
