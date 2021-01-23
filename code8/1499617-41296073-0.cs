    public class CurrentUser
    {
        //some properties
    }
    
    public class ApplicationUser : CurrentUser
    {
        //additional properties
    }
    
    public class MyContext : DbContext
    {
        public DbSet<CurrentUser> Users { get; set; }
    }
