    public static bool TryGet<T>(this ICache cache, string key, out T result)
    {
        var obj = cache.Get(key);
        if (obj == null)
        {
            result = default(T);
            return false;
        }
        result = (T)obj;
        return true;
    }
