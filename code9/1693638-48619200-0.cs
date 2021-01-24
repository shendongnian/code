    // ...
    // Can be memory or redis
    if (AppSettings.Get("CacheClient", "memory") == "redis")
    {
        Container.Register<IRedisClientsManager>(c => new PooledRedisClientManager("localhost:6379"));
        Container.Register(c => c.Resolve<IRedisClientsManager>().GetCacheClient());
    }
    else
        Container.Register<ICacheClient>(new MemoryCacheClient());
    // ...
