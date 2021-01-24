    public class AppDbContext: DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
          :base(options)
        { }
    
    }
