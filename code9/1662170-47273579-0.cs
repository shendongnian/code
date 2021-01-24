    class BlockAndDelayExample
    {
         private readonly MemoryCache _memCache;
         private readonly CacheItemPolicy _cacheItemPolicy;
         private const int CacheTimeMilliseconds= 500;
    
         public BlockAndDelayExample(string demoFolderPath)
         {   
             _memCache = MemoryCache.Default;
    
             var watcher = new FileSystemWatcher()
             {
                 Path = demoFolderPath,
                 NotifyFilter = NotifyFilters.LastWrite,
                 Filter = "*.txt"
             };
    
             _cacheItemPolicy = new CacheItemPolicy()
             {
                 RemovedCallback = OnRemovedFromCache
             };
    
             watcher.Changed += OnChanged;
             watcher.EnableRaisingEvents = true;
         }
    
         // Add file event to cache for CacheTimeMilliseconds
         private void OnChanged(object source, FileSystemEventArgs e)
         {
             _cacheItemPolicy.AbsoluteExpiration = 
             DateTimeOffset.Now.AddMilliseconds(CacheTimeMilliseconds);
             // Only add if it is not there already (swallow others)
             _memCache.AddOrGetExisting(e.Name, e, _cacheItemPolicy);
         }       
         // Handle cache item expiring
         private void OnRemovedFromCache(CacheEntryRemovedArguments args)
         {
             if (args.RemovedReason != CacheEntryRemovedReason.Expired) return;
    
             // Now actually handle file event
             var e = (FileSystemEventArgs)args.CacheItem.Value;
         }      
     }
