    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
         
        // Create the Autofac container builder.
        var builder = new ContainerBuilder();
        // Add any Autofac modules or registrations.
        builder.RegisterModule(new AutofacModule());
        // Populate the services.
        builder.Populate(services);
        // Build the container.
        var container = builder.Build();
        // Resolve and return the service provider.
        return container.Resolve<IServiceProvider>();
    }
