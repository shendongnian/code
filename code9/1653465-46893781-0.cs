    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    
        CreateContainer().Wait();
    
        services.AddSingleton<Infrastructure.Logging.Contracts.ILogger, Infrastructure.Logging.Standard.Logger>();
    }
