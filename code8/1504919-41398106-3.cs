    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, YourApplication.Migrations.Configuration>("MyConnection")); 
        }
        //Every time you need to add new Table you add them here.
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //And Map them here
            modelBuilder.Configurations.Add(new UsersMap());
        }
    }
