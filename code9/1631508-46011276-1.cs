    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext,Configuration>("MyConnection")); 
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //here you can MAP Your Models/Entities
        }
    }
