    public static async Task<T> AddOrGetExistingAsync<T>(
        this ObjectCache cache,
        string key,
        Func<Task<T>> valueFactory,
        CacheItemPolicy policy)
    {
        var newValue = new AsyncLazy<T>(valueFactory);
        var oldValue = cache.AddOrGetExisting(key, newValue, policy) as Lazy<T>;
    
        try
        {
            return oldValue != null ? oldValue.Value : await newValue.Value;
        }
        catch
        {
            cache.Remove(key);
            throw;
        }
    }
