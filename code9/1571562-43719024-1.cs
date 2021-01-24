    public void ConfigureServices(IServiceCollection services) {
        // Add framework services.
        services.AddMvc();
        services.AddSingleton<IEntriesService, EntriesService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IEntriesRepository, EntriesRepository>();
        //...add other dependencies. 
    }
