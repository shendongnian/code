    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Post> Post { get; set; }
    }
