    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IModelFactory, ModelFactory.Current>();
    
        // Add framework services.
        services.AddMvc();
    }
