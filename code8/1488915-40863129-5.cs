    public partial class VisualJobsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        private IConfigurationRoot _config;
        public VisualJobsDbContext() { }
        public VisualJobsDbContext(IConfigurationRoot config, DbContextOptions<VisualJobsDbContext> options) : base(options)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@_config["ConnectionStrings:VisualJobsContextConnection"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {....
