    public void ConfigureServices(IServiceCollection services)
            {
                // Add framework services.
                services.AddApplicationInsightsTelemetry(Configuration);
    
                services.AddSingleton(x => new InMemoryDataProvider(connString));
                services.AddSingleton<IDataProvider, InMemoryDataProvider>(x => x.GetService<InMemoryDataProvider>());
                services.AddSingleton<IAnimal, Dog>(d=> new Dog(someString, d.GetService<IDataProvider>()));
    
                services.AddMvc();
            }
     
