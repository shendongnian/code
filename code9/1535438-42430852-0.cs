    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<AggregateRootMapping<Order>, OrderAggregateRootMapping>();
        services.AddScoped<Repository<Order>>();
    
        // Add framework services.
        services.AddMvc();
    }
