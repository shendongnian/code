    public class MyDatabaseContext : DbContext
    {
        /// <summary>
        /// The constructor for the database
        /// </summary>
        public MyDatabaseContext()
        {
            _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "Monitoring_Tool_LocalDb.db"); // For iOS, test with #if _IOS
            //_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Monitoring_Tool_LocalDb.db"); // For Android
            //_path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "exrin.db"); // For uwp
            this.Database.EnsureCreated();
        }
        public DbSet<MyObject> MyObjects { get; set; }
        /// <summary>
        /// The path where the database is saved
        /// </summary>
        private string _path = string.Empty;
        /// <summary>
        /// The configuration for the database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_path}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // Your ModelBuilder modifications
        }
    }
