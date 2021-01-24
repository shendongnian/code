    public class MyCachedRepository : IMyRepository
    {
        private readonly IMyRepository _baseRepository;
        private readonly ObjectCache _cache;
     
        public MyCachedRepository(IMyRepository baseRepository, ObjectCache cache)
        {
            _baseRepository = baseRepository;
            _cache = cache;
        }
     
        public string GetById(string id)
        {
            var value = _cache.Get(id) as string;
     
            if (value == null)
            {
                value = _baseRepository.GetById(id);
                if (value != null)
                    _cache.Set(id, value, GetPolicy());
            }
     
            return value;
        }
     
        private CacheItemPolicy GetPolicy()
        {
            return new CacheItemPolicy
            {
                UpdateCallback = CacheItemRemoved,
                SlidingExpiration = TimeSpan.FromMinutes(0.1),  //set your refresh interval
            };
        }
     
        private void CacheItemRemoved(CacheEntryUpdateArguments args)
        {
            if (args.RemovedReason == CacheEntryRemovedReason.Expired || args.RemovedReason == CacheEntryRemovedReason.Removed)
            {
                var id = args.Key;
                var updatedEntity = _baseRepository.GetById(id);
                args.UpdatedCacheItem = new CacheItem(id, updatedEntity);
                args.UpdatedCacheItemPolicy = GetPolicy();
            }
        }
    }
    
    
