    public class CustomConfigurationDbContext : ConfigurationDbContext
    {
        public CustomConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options,
            ConfigurationStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //...
    
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
