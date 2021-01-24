    public IServiceProvider ConfigureServices(IServiceCollection services) {
        services.AddMvc();
        // Add other framework services
    
        // Add custom provider
        var container = new ServiceResolver(services).GetServiceProvider();
        return container;
    }
