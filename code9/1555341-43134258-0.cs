    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbModelCacheKeyProvider, IDisposable
    {
            public ApplicationDbContext(string connection)
                : base(connection)
            {            
                ...
            }
