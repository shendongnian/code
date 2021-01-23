    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        services.Configure<ConsulOptions>(Configuration);
    }
