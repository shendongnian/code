    public partial class MyDatabaseContext : DbContext
    {
        public virtual DbSet<Student> students { get; set; }
    
    
    
        public MyDatabaseContext() : base("MyDatabaseContextConnectionString")
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDatabaseContext, Migrations.Configuration>());
        }
    
    
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // here we want to define the entities structure
        }    
    }
