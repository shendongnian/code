    public class MyDbContext : AbpDbContext
    {
        public DbSet<Test> Tests { get; set; }
    
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
    }
