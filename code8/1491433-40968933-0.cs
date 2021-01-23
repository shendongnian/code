    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
       
    
        // Add application services.
        services.AddTransient<HomeController>();
        services.AddTransient<IOrderService , OrderService >();
        services.AddTransient<IDeliveryService, DeliveryService>();
        services.AddScoped<IDataContextService   , YourDataContextService  >();
    }
