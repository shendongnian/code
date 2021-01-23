    public class TestDbContext: DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options): base(options)
        { }
        public DbSet<TestModel> TestModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestModel>().ToTable("TestTable");
        }
    }
