    var cache = new CacheService();
    container.RegisterConditional(typeof(IBuilder),
        Lifestyle.Transient.CreateRegistration<Builder>(
            () => new Builder(cache),
            container),
        c => c.Consumer.ImplementationType.GetCustomAttribute<UseCacheAttribute>() != null);
    container.RegisterConditional(typeof(IBuilder),
        Lifestyle.Transient.CreateRegistration<Builder>(
            () => new Builder(new NullCacheService()), 
            container),
        c => !c.Handled);
