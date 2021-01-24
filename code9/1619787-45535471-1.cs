    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  {
        }
    
        //...other code removed for brevity
    }
