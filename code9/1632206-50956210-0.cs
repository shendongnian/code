    public class TenantContext : DbContext, IDbModelCacheKeyProvider
    {
        string IDbModelCacheKeyProvider.CacheKey {
            get { return tenentID.ToString(); }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
   
