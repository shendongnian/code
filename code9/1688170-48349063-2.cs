    public static T Get<T>(this ICache cache, string key)
    {
        var obj = cache.Get(key);
        return obj == null ? default(T) : (T)obj;
    }
