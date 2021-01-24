    public class BloggingContext : DbContext
    {
        public BloggingContext(){          // << The reason....
        }
        public BloggingContext(DbContextOptions<BloggingContext> options)
             : base(options)
        { }
       public DbSet<Blog> Blogs { get; set; }
    }
