    IServiceCollection serviceCollection = new ServiceCollection();
    serviceCollection.AddScoped<IDependency, Dependency>();
    serviceCollection.AddScoped<IEntity>(provider => 
        new Entity(provider.GetService<IDependency>(), "https://example.com/")
    );
