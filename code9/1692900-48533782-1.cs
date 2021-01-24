    public class IsolatedContext : CustomContext
    {
        public IsolatedAstootContext(DbContextOptions<IsolatedCustomContext> options,
            DbAuthorizationOptions<CustomContext> authorizationOptions, 
            IMemoryCache memoryCache) : base(options, authorizationOptions, memoryCache)
        {
        }
    }
