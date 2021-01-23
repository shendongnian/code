    public class OldDbContext: DbContext
    {
        public DbSet<MyClass> MyClasses { get; set; }
        public DbSet<User> Users{ get; set; }
    }  
