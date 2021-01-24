    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<BloggingContext> options)
          :base(options)
        { }
    
    }
