     public partial class CDBContext : DbContext
       {
        public CDBContext (string ConnectionString) : base(new DbContextOptionsBuilder().UseSqlServer(ConnectionString).Options)
        {
        }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Query<MediaData>();            
        }
