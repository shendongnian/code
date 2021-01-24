    public class AuthorizedDbContext : DbContext
    {
        Dictionary<Type, MethodInfo> _filterMap;
        DbAuthorizationOptions _authOptions;
    
        private static Dictionary<Type, Dictionary<Type, MethodInfo>> _cache;
    
        static AuthorizedDbContext() => _cache = new Dictionary<Type, Dictionary<Type, MethodInfo>>();
    
        public AuthorizedDbContext(DbContextOptions options) : base(options)
        {
        }
    
        protected Dictionary<Type, MethodInfo> CreateGenericFilterMap()
        {
            var genericFilterCache = new Dictionary<Type, MethodInfo>();
            foreach (var entityType in this.Model.GetEntityTypes().Select(e => e.ClrType))
            {
                var genericMethod = typeof(QueryFilterExtensions).GetExtensionMethodFor(typeof(DbContext))
                    .Where(x => x.Name == nameof(QueryFilterExtensions.Filter))
                    .Where(x => x.IsGenericMethod && x.IsGenericMethodDefinition)
                    //TODO switch this to single and filter properly
                    .First();
    
                genericFilterCache[entityType] = genericMethod.MakeGenericMethod(entityType);
            }
    
            return _cache[GetType()] = genericFilterCache;
        }
    
        public Dictionary<Type, MethodInfo> GetCache() => _cache[GetType()];
    }
