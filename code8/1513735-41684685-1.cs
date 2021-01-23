         private static string _key = "foo";
         private static readonly MemoryCache _cache = MemoryCache.Default;
        
         //Store Stuff in the cache  
       public static void StoreItemsInCache()
       {
          List<string> itemsToAdd = new List<string>();
             
          //Do what you need to do here. Database Interaction, Serialization,etc.
           var cacheItemPolicy = new CacheItemPolicy()
           {
             //Set your Cache expiration.
             AbsoluteExpiration = DateTime.Now.AddDays(1)
            };
             
           _cache.Add(_key, itemsToAdd, CacheItemPolicy);
        }
    
        //Get stuff from the cache
        public static List<string> GetItemsFromCache()
        {
          if (!_cache.Contains(_key))
                   StoreItemsInCache();
            
            return _cache.Get(_key) as List<string>;
        }
             
