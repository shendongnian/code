    public class MyDbContext : AbpDbContext
    {
        public DbSet<Product> Products { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
    }
