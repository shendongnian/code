        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new WebListenerCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        logger.LogStatelessServiceStartedListening<WebApi>(url);
                        return new WebHostBuilder().UseWebListener()
                                    .ConfigureServices(
                                        services => services
                                            .AddSingleton(serviceContext)
                                            .AddSingleton(logger)
                                            .AddTransient<IServiceRemoting, ServiceRemoting>())
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseStartup<Startup>()
                                    .UseUrls(url)
                                    .Build();
                    }))
            };
        }
