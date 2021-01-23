    public void ConfigureServices(IServiceCollection services)
    {
        // add options services
        services.AddOptions();
        // configure OtherDbOptions using code
        services.Configure<OtherDbOptions>(options =>
        {
            options.ConnectionString = "value from appsettings.json";
        });
        
        // register OtherDbService for DI
        services.AddTransient<OtherDbService>();
        // other configurations
        ...
    }
