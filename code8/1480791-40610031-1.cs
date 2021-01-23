    using DotNetNuke.Common.Utilities;
    public bool cacheExists(string key)
    {
        return DataCache.GetCache(key) != null;
    }
    
    public void setCache<T>(T value, string key)
    {
        DataCache.SetCache(key, value);
    }
    
    public T getCache<T>(string key)
    {
        return (T)DataCache.GetCache(key);
    }
