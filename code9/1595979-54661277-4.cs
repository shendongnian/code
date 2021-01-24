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
        }
    }
