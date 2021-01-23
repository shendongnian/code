    services.AddScoped<MyRepository>();
    services.AddScoped<IMyRepository, CachedMyRepositoryDecorator>(
        provider => new CachedMyRepositoryDecorator(
            provider.GetService<MyRepository>(),
            provider.GetService<IMemoryCache>()
        ));
