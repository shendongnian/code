    public partial class MyDbContext : DbContext
    {
        public virtual DbSet<Table> Table { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {}
    }
