    public class PhotographRepository : IPhotograpRepository
    {
        private readonly IMemoryCache _cache;
        public PhotographReposiory(IMemoryCache cache, ...)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        public async Task Update(PhotographEntity entity)
        {
            // update your entity here
            await _context.SaveChangesAsync();
            // this invalidates your memory cache. Next call to _cache.TryGetValue
            // results in a cache miss and the new entity is fetched from the database
            _cache.Remove(GetClientCacheKey(entityName, clientId));
        }
    }
