    public class DomainContextFactory : IDbContextFactory<DomainContext>
    {
        public string BasePath { get; protected set; }
        public DomainContext Create()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var basePath = AppContext.BaseDirectory;
            return Create(basePath, environmentName);
        }
        public DomainContext Create(DbContextFactoryOptions options)
            => Create(options.ContentRootPath, options.EnvironmentName);
        private DomainContext Create(string basePath, string environmentName)
        {
            BasePath = basePath;
            var configuration = Configuration(basePath, environmentName);
            var connectionString = ConnectionString(configuration.Build());
            return Create(connectionString);
        }
        private DomainContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"{nameof(connectionString)} is null or empty", nameof(connectionString));
            }
            var optionsBuilder = new DbContextOptionsBuilder<DomainContext>();
            return Configure(connectionString, optionsBuilder);
        }
        protected virtual IConfigurationBuilder Configuration(string basePath, string environmentName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("constr.json")
                .AddJsonFile($"constr.{environmentName}.json", true)
                .AddEnvironmentVariables();
            return builder;
        }
        protected virtual string ConnectionString(IConfigurationRoot configuration)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];
            return connectionString;
        }
        protected virtual DomainContext Configure(string connectionString, DbContextOptionsBuilder<DomainContext> builder)
        {
            builder.UseSqlServer(connectionString, opt => opt.UseRowNumberForPaging());
            
            DomainContext db = new DomainContext(builder.Options);
            return db;
        }
        DomainContext IDbContextFactory<DomainContext>.Create(DbContextFactoryOptions options)
            => Create(options.ContentRootPath, options.EnvironmentName);
    }
