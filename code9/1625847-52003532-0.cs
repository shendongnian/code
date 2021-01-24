    public class BloggingContextFactory : IDesignTimeDbContextFactory<BloggingContext>
        {
            public BloggingContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
                optionsBuilder.UseSqlite("Data Source=blog.db");
    
                return new BloggingContext(optionsBuilder.Options);
            }
        }
