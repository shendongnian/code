    public class YourContext : DbContext
        {
            public YourContext() : base("name=DefaultConnection")
            {
    
            }
    
            public DbSet<aaaa> Aaaas { get; set; }
        }
