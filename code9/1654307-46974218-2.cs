    public class SecurityTestsFixture : IDisposable
    {
        public DatabaseFixture Dbfixture { get; private set; }
        public StartupTestFixture Startupfixture { get; private set; }
        public SecurityTestsFixture()
        {
            Startupfixture = new StartupTestFixture();
            Dbfixture = new DatabaseFixture(Startupfixture);
        }
        public void Dispose()
        {
            // clean up code
            Dbfixture.Dispose();
        }
        public class StartupTestFixture
        {
            public string SqlConnString { get; private set; }
            public StartupTestFixture()
            {
                SqlConnString = ConfigurationManager.AppSettings["SqlConnectionString"];
                // other startup code
            }
        }
        public class DatabaseFixture : IDisposable
        {
            public SqlConnection Db { get; private set; }
            public DatabaseFixture(StartupTestFixture sFixture)
            {
                Db = new SqlConnection(sFixture.SqlConnString);
                // initialize data in the test database
            }
            public void Dispose()
            {
                // clean up test data from the database
            }
        }
    }
