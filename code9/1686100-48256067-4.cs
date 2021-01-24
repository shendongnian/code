    public IServiceProvider ConfigureServices(IServiceCollection services) {
        //...
    
        services.AddScoped<CustomActionFilter>();
        //...
    
        // Autofac
        services.AddAutofac();
    
        var builder = new ContainerBuilder();
    
        //core integration
        builder.Populate(services);
    
        //support keyed filtering
        builder.RegisterType<Service>()
               .Keyed<IService>("test")
               .SingleInstance();
    
        var container = builder.Build();    
        var serviceProvider = new AutofacServiceProvider(container);
        return serviceProvider;
    }
