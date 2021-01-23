    namespace SharedDataContext
    {
        public class BaseDbContext : DbContext
        {
            public BaseDbContext() : base("CFConnection")
            { }
    
            public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    
        }
    
        public partial class ApplicationUser
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
