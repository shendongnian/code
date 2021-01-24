    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddMvc();
        
        var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
        services.AddSingleton(appSettings);
    }
