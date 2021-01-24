    public class PhotographRepository : IPhotograpRepository
    {
        private readonly ApplicationDbContext _context;
        public PhotographReposiory(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Update(PhotographEntity entity)
        {
            // update your entity here
            await _context.SaveChangesAsync();
        }
    }
    public class CachedPhotographRepository : IPhotograpRepository
    {
        private readonly IMemoryCache _cache;
        private readonly IPhotograpRepository _repository;
        public CachedPhotographRepository(IPhotograpRepository repository, IMemoryCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _repository = _repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task Update(PhotographEntity entity)
        {
            // do the update in the passed in repository
            await _repository.Update(entity);
            // if no exception is thrown, it was successful
            _cache.Remove(GetClientCacheKey(entityName, clientId));
        }
    }
