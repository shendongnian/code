    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddSingleton<IServiceProviderProxy, HttpContextServiceProviderProxy>();
        .......
    }
