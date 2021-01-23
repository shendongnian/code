     public class BloggingContext : DbContext
     {
    public BloggingContext()
        :      base("BlogDB")
      {
      }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; } 
     }
    
