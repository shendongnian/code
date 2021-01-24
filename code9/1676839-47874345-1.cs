    public string GetValue(int key)
    {
        CacheItem<string> item;
        if (_cache.TryGetValue(key, out item) && item.IsValid)
            return item.Value;
        return null; // Signifies no entry in cache or entry has expired.
    }
