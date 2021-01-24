    container.Register<IAppSettingsLoader, FileAppSettingsLoader>(Lifestyle.Singleton);
    container.RegisterDecorator<IAppSettingsLoader, CachedAppSettingsLoader>(Lifestyle.Singleton);
    container.RegisterSingleton(new CachedAppSettingsLoaderSettings
    {
        Cache = MemoryCache.Default,
        Policy = new CacheItemPolicy { ... },
        CacheKey = "AuthorizationRecords" 
    });
