    public class DataContext : DbContext, IDataContext
    {
        public DbSet<User> Users { get; set; }
        
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
