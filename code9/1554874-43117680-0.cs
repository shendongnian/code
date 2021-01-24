    using System.Runtime.Caching;  
    
    public class cacheservice: ICacheservice
    {
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
            }
            return item;
        }
    }
    
    interface ICacheService
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;
    }
