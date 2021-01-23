    var collection = new ServiceCollection();
    
    collection.Scan(scan => scan
        .FromAssemblyOf<ITransientService>()
            .AddClasses(classes => classes.AssignableTo<ITransientService>())
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            .AddClasses(classes => classes.AssignableTo<IScopedService>())
                .As<IScopedService>()
                .WithScopedLifetime());
