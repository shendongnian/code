    public interface IConnectionSettings
    {
        string MyDatabaseConnectionString { get; }
    }
    class MyClass
    {
        private readonly IConnectionSettings _connectionSettings;
        public MyClass(IConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionSettings.MyDatabaseConnectionString);
        }
    }
