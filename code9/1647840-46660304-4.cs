    public partial class ApplicationDbContext: DbContext
    {
        public AppContext(): base("name=ApplicationDbContext")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                
        }
        
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
