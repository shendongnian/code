    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<TContext> options) : base(options) { }
        public DbSet<Post> Post { get; set; }
    }
