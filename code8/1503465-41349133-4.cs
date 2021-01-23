    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, YourApplication.Migrations.Configuration>("MyConnection")); 
        }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //here you can MAP Your Models/Entities, but i am going to show you something more interesting. so keep up. 
            modelBuilder.Configurations.Add(new UsersMap());
        }
    }
