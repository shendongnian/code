      public class VAMPModelContext : DbContext
      {
        private VAMPModelContext(string _ConnectionString)
          : base(_ConnectionString)
        {
          Database.SetInitializer<VAMPModelContext>(null);
        }
    
        private VAMPModelContext(DbCompiledModel compiledModel, string connectionString)
          : base(compiledModel)
        {
          Database.SetInitializer<VAMPModelContext>(null);
          Database.Connection.ConnectionString = connectionString;
        }
    
        public static VAMPModelContext CreateContext(string suffix)
        {
          string connectionString = ConfigurationManager.ConnectionStrings["VAMPTest"].ConnectionString;
          VAMPModelContext dummyContext = new VAMPModelContext(connectionString);
    
          DbModelBuilder builder = new DbModelBuilder(DbModelBuilderVersion.Latest);
          builder.Configurations.Add(new EntityTypeConfiguration<VAMPModel>());
    
          // Construct model mapping for ORM
          string tableName = "VAMPModels" + suffix;
          builder.Entity<VAMPModel>().ToTable(tableName);
    
          // Compile ORM object, hard link connection
          DbConnection dummyConnection = dummyContext.Database.Connection;
          DbCompiledModel compiledModel = builder.Build(dummyConnection).Compile();
    
          // Finally make our database context
          dummyContext = new VAMPModelContext(compiledModel, connectionString);
    
          return dummyContext;
        }
    
        public virtual DbSet<VAMPModel> ModelsList { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          // Adjust field properties for model
          modelBuilder.Entity<VAMPModel>()
              .Property(e => e.ModelCode)
              .IsUnicode(false);
    
          modelBuilder.Entity<VAMPModel>()
              .Property(e => e.PriceAUD)
              .HasPrecision(18, 0);
    
          base.OnModelCreating(modelBuilder);
        }
      }
