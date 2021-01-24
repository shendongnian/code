    public abstract class BaseContext : DbContext
    {
        private readonly DatabaseGeneratedOption _databaseGeneratedOption;
    
        protected BaseContext(string conString, DatabaseGeneratedOption databaseGeneratedOption)
            : base(conString)
        {
            this._databaseGeneratedOption = databaseGeneratedOption;
        }
    
        public DbSet<Planet> Planets { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>().HasKey(p => p.ID);
            modelBuilder.Entity<Planet>().Property(p => p.ID)
                        .HasDatabaseGeneratedOption(this._databaseGeneratedOption);
            base.OnModelCreating(modelBuilder);
        }
    }
