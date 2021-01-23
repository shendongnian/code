    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddMvc();
        services.AddSimpleInjectorTagHelperActivation(container);
        // rest of your configuration
    }
