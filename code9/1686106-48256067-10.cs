    public IServiceProvider ConfigureServices(IServiceCollection services) {
        //...
    
        // Autofac
        services.AddAutofac();
    
        var builder = new ContainerBuilder();
    
        //core integration
        builder.Populate(services);
    
        // Register the components getting filtered with keys
        builder.RegisterType<Service1>().Keyed<IService>("test1");
        builder.RegisterType<Service2>().Keyed<IService>("test2");
        // Attach the filtering behavior to the component with the constructor
        builder.RegisterType<CustomActionFilter>().WithAttributeFiltering();
    
        var container = builder.Build();    
        var serviceProvider = new AutofacServiceProvider(container);
        return serviceProvider;
    }
