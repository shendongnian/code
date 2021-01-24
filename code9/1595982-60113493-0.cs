    public class ConfigurationDataContext : ConfigurationDbContext<ConfigurationDataContext>
    {
        public ConfigurationDataContext(DbContextOptions<ConfigurationDataContext> options, ConfigurationStoreOptions storeOptions)
        : base(options, storeOptions)
        {
        }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
    
            builder.ApplyConfigurationsFromAssembly(typeof(MyConfigurationsAssemby).Assembly);
        }
    }
