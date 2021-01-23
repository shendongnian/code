    var services = new ServiceCollection();
    services.AddLogging();
    // Initialize Autofac
    var builder = new ContainerBuilder();
    // Use the Populate method to register services which were registered
    // to IServiceCollection
    builder.Populate(services);
    // Build the final container
    IContainer container = builder.Build();
