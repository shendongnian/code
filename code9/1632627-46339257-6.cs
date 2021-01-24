    class YourModel : DbContext
    {
        // Your context has been configured to use a 'YourModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'YourProject.YourModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'YourModel' 
        // connection string in the application configuration file.
        public YourModel()
            : base("name=YourModel")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<YourModel>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
            Database.SetInitializer(new SqliteDropCreateDatabaseWhenModelChanges<YourModel>(modelBuilder));
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<YourTableClass> YourTable { get; set; }
    }
    [Table("YourTable")]
    public class YourTableClass
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public FileOperation Oper { get; set; }
        [Required, Index]
        public OperationState State { get; set; }
        [Index]
        public string Proc { get; set; }
        [Required]
        public string Src { get; set; }
        public DateTime Timestamp { get; set; }
        // etc.
    }
