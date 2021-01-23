    public async Task<T> GetOrCreateAsync(string cacheKey, Func<Task<T>> doWorkAsync)
    {
        T cachedObject = null;
        if (string.IsNullOrEmpty(cacheKey) || string.IsNullOrWhiteSpace(cacheKey))
            return cachedObject;
        try
        {
            cachedObject = await doWorkAsync();
            localCache.Add(cacheKey, cachedObject, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }
        catch (Exception)
        {
            cachedObject = null;
        }
        finally
        {
        }
        return cachedObject;
    }
