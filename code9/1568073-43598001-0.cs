    public partial class FooContext : DbContext
    {
        private FooContextOptions _options;
        public FooContext(FooContextOptions options)
        {
            _options = options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_options.ConnectionString);
        }
    }
