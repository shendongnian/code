    public class MyDbContext : DbContext
    {
        public SureshotDbContext()
        {
            // This allows for instantiation at design time.
        }
        public MyDbContext(DbContextOptions<MyDbContext> options) :
            base(options)
        {
            // This allows for configuration in real applications.
        }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder.UseSqlServer(nameof(TDbContext));
        }
    }
