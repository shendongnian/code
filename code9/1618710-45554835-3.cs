    public partial class YourDBEntities : DbContext
    {
        public YourDBEntities(string connectionString)
            : base(connectionString)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        ....
    }
