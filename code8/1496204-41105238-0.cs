    public interface ICache
    {
        T Get<T>(string key, Func<T> updateExpression = null, int cacheDuration=0);       
    }
    public class InMemoryCache : ICache
    {
        readonly IMemoryCache memoryCache;
        public InMemoryCache(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public T Get<T>(string key, Func<T> updateExpression = null,int cacheDuration=0)
        {
            object result;
            if (memoryCache.TryGetValue(key,out result))
            {
                return (T) result;
            }
            else
            {
                if (updateExpression == null)
                {
                    return default(T);
                }
                var data = updateExpression();
                if (data != null)
                {
                    var options = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddSeconds(cacheDuration)
                    };
                    this.memoryCache.Set(key, data, options);
                    return data;
                }
                return default(T);
            }
        }
    }
