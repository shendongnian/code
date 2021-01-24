    ObjectCache cache = MemoryCache.Default;
    var key = "MyAwesomeSettings";
    var settings = cache.Get(key);
    if (settings == null)
    {
        settings = // query settings;
        cache.Add(key, settings, DateTimeOffset.UtcNow.AddHours(1));
    }
