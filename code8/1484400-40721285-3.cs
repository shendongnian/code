    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IWorkingEnvironment, AspNetWorkingEnvironment>();
    
        // etc...
    }
