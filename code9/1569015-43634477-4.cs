    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IModelFactory, ModelFactory>();
    
        // Add framework services.
        services.AddMvc();
    }
