    namespace WebApp.Models
    {
        public class MultiTenantContext : DbContext
        {
            public MultiTenantContext() : base("DB")
            {
            }
            public DbSet<Tenant> Tenants { get; set; }
        }
    }
