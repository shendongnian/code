    public void ConfigureServices(IServiceCollection services)
            {
                // Add framework services.
                services.AddApplicationInsightsTelemetry(Configuration);
    
                var connString = "connectionString";
                var someString = "some required info";
                services.AddSingleton<IDataProvider, InMemoryDataProvider>(x => new InMemoryDataProvider(connString));
                services.AddSingleton<IAnimal, Dog>(d=> new Dog(someString, d.GetService<InMemoryDataProvider>()));
    
                services.AddMvc();
            }
     
