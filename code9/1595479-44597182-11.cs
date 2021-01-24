    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        // Add services to the collection.
        services.AddMvc();
        // Create the container builder.
        var builder = new ContainerBuilder();
        // Register dependencies, populate the services from
        // the collection, and build the container. If you want
        // to dispose of the container at the end of the app,
        // be sure to keep a reference to it as a property or field.
        builder.RegisterType<MyType>().As<IMyType>();
        builder.Populate(services);
        this.ApplicationContainer = builder.Build();
        // Create the IServiceProvider based on the container.
        return new AutofacServiceProvider(this.ApplicationContainer);
    }
