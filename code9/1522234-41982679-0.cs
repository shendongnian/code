    public T Get<T>(string key, Func<T> getItemDelegate, int duration) where T : class
    {
        var cache = GetCache();
        var item = SingletonCacheManager.Instance.Get<ListMap>>(key) as T;
        if (item != null) return item;
        item = getItemDelegate();
        SingletonCacheManager.Instance.Add<T>(item, key, duration);
        return item;
    }
