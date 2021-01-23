    public partial class MyContext : DbContext
        {
            private readonly IConfiguration _configuration;
            private IDbConnection DbConnection { get; }
    
            public MyContext(DbContextOptions<MyContext> options, IConfiguration configuration)
                : base(options)
            {
                this._configuration = configuration;
                DbConnection = new SqlConnection(this._configuration.GetConnectionString("Connection1"));
            }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(DbConnection.ToString());
                }
            }
        }
