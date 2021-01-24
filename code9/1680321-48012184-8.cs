    public class AppDbContext : DbContext, IAppDbContext {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) {
        }
    }
    public class LogDbContext : DbContext, ILogDbContext {
        public AppDbContext(DbContextOptions<LogDbContext> dbContextOptions) : base(dbContextOptions) {
        }
    }
