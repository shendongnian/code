    public interface ITenantDbContextFactory
    {
        ApplicationContext Create(string tenantId);
    }
    public class TenantDbContextFactory()
    {
        private ApplicationContext context;
        public TenantDbContextFactory()
        {
        }
        public ApplicationContext Create(string tenantId) 
        {
            if(this.context==null) 
            {
                var connectionString = GetConnectionForTenant(tenantId);
                var dbContextBuilder = new DbContextOptionsBuilder();
                dbContextBuilder.UseSqlServer(connectionString);
                this.context = new ApplicationContext(dbContextBuilder);
            }
            return this.context;
        }
    }
