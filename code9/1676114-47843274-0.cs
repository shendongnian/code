    public class BolgDbContext : DbContext
    {
        public BolgDbContext() : base("name=BlogDbContext") { }
        public DbSet<Post> Posts { get; set; }
    }
