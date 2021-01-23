    public void ConfigureServices(IServiceCollection services)
    {
       services.AddTransient<ICache, InMemoryCache>();
       services.AddMemoryCache();
    }
