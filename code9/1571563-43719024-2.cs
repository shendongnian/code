    public void ConfigureServices(IServiceCollection services) {
        // Add framework services.
        services.AddMvc();
        services.AddSingleton<IEntriesService, EntriesService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IEntriesRepository, EntriesRepository>();
        services.AddSingleton<IConnectionFactory, ConnectionFactory>();
        //...add other dependencies. 
    }
