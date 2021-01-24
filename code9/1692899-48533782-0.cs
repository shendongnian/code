    public partial class CustomContext : DbContext
    {
        public CustomContext(DbContextOptions<CustomContext> options,
             DbAuthorizationOptions<CustomContext> authorizationOptions, IMemoryCache memoryCache)
             : base(options, authorizationOptions, memoryCache)
        {
        }
        protected CustomContext(DbContextOptions options,
             DbAuthorizationOptions<CustomContext> authorizationOptions, IMemoryCache memoryCache)
             : base(options, authorizationOptions, memoryCache)
        {
        }
    }
