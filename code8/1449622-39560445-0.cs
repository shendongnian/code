    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
        public Entities(string connectionString)
            : base(ConnectionString())
        {
        }
        private static string ConnectionString()
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "MyServer", //When this works it will be dynamic
                InitialCatalog = "XXX", //When this works it will be dynamic
                PersistSecurityInfo = true,
                IntegratedSecurity = true,
                MultipleActiveResultSets = true,
            };
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                Metadata = "res://*/Models.Erp1Model.csdl|res://*/Models.Erp1Model.ssdl|res://*/Erp1Model.msl",
                ProviderConnectionString = sqlBuilder.ConnectionString
            };
            return entityConnectionStringBuilder.ConnectionString;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public virtual DbSet<Items> Items { get; set; }
    }
