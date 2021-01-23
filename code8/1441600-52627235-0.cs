    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("name=BlogDB")
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
