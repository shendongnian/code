    public class Cache<T>
    {
        public void TryGetOrSet( string cacheKey, Func<T> getData, out T returnData, CacheItemPolicy policy = null )
        {
           ...
        }
    }
