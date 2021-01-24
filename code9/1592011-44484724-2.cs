    //TContext is your DbContext actual type
    serviceCollection.TryAdd(new ServiceDescriptor(typeof(TContext), typeof(TContext), contextLifetime));
    
    serviceCollection.TryAddSingleton(p => DbContextOptionsFactory<TContext>(p, optionsAction));
    serviceCollection.AddSingleton<DbContextOptions>(p => p.GetRequiredService<DbContextOptions<TContext>>());
    
