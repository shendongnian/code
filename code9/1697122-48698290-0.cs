    public class MultiTenantContext : DbContext
    {
        private UserContext _userContext;
    
        public MultiTenantContext(DbContextOptions options, UserContext userContext) : base(options)
        {
            _userContext = userContext;
        }
    }
