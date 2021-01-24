    public class TestDbContext : AbpDbContext
    {
        public DbSet<Test> Tests { get; set; }
    
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }
    }
