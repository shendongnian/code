    public class CustomDbContext : IdentityDbContext<CustomIdentity, CustomRole, string>
    {
        private readonly IConfigManager _configManager;
        public CustomDbContext(DbContextOptions<CustomDbContext> options, IConfigManager configManager) : base(options)
        {
            this._configManager = configManager;
        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configManager._config.ConnectionStrings.FirstOrDefault(c => c.id == "IdentityDatabase").connectionString);
        }
    }
