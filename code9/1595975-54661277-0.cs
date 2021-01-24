    using IdentityServer4.EntityFramework.DbContexts;
    using IdentityServer4.EntityFramework.Options;
    using Microsoft.EntityFrameworkCore;
    namespace DL.STS.Data.ConfigurationStore.EFCore
    {
        public class AppConfigurationDbContext : ConfigurationDbContext
        {
            public AppConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options, 
                ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
            {
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                // You can customize more here!
            }
        }
    }
