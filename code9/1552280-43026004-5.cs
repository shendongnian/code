    using (var ignite = Ignition.Start())
    {
        var cacheCfg = new CacheConfiguration
        {
            ReadThrough = true,
            WriteThrough = true,
            KeepBinaryInStore = false,  // Depends on your case
            CacheStoreFactory = new OracleStoreFactory()
        };
        var cache = ignite.CreateCache<int, MyClass>(cacheCfg);
        cache.Get(1);  // OracleStore.Load is called.
    }
