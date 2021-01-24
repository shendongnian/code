    public class eDbContext : DbContext
    {
        public IebContext()
            : base("name=ConnectionStringName")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<eDbContext, Migrations.Configuration>("CatalogName"));
        }
        public DbSet<Task> Tasks{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskMap());
        }
    }
