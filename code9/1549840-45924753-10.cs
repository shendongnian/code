    /*
     * Startup.cs
     */
    public IConfigurationRoot Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        //...rest of services
        services.AddSingleton<IDbService, DbService>();
    
        //...rest of services
    }
