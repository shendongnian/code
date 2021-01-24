    public class MyDbContextFactory : IDbContextFactory<MyDbContext>
    {
        private readonly string _connectionString;
        public MyDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public MyDbContextFactory()
        {
            _connectionString = "MIGRATION_ONLY_DONT_USE_ITS_FAKE!";
        }
        public MyDbContext Create()
        {
            return new MyDbContext(_connectionString);
        }
    }
