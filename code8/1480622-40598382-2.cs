    public class MyModel
    {
        public string SomeValue { get; set; }
    }
    public interface IMyRepository
    {
        IEnumerable<MyModel> GetModel();
    }
    public class MyRepository : IMyRepository
    {
        public IEnumerable<MyModel> GetModel()
        {
            return Set<MyModel>().FromSql("pr_GetMyModel");
        }
    }
    public class CachedMyRepositoryDecorator : IMyRepository
    {
        private readonly IMyRepository repository;
        private readonly IMemoryCache cache;
        private const string MyModelCacheKey = "myModelCacheKey";
        private MemoryCacheEntryOptions cacheOptions;
        // alternatively use IDistributedCache if you use redis and multiple services
        public CachedMyRepositoryDecorator(IMyRepository repository, IMemoryCache cache)
        {
            this.repository = repository;
            this.cache = cache;
            // 1 day caching
            cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromDays(1));
        }
        public IEnumerable<MyModel> GetModel()
        {
            // Check cache
            var value = cache.Get<IEnumerable<MyModel>>("myModelCacheKey");
            if(value==null)
            {
                // Not found, get from DB
                value = repository.GetModel();
                // write it to the cache
                cache.Set("myModelCacheKey", value, cacheOptions);
            }
            return value;
        }
    }
