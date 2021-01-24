    //similar to base class
    public class DatabaseFixture : IDisposable
    {
        public SqlConnection Db { get; private set; }
        public DatabaseFixture()
        {
            Db = new SqlConnection("MyConnectionString");
    
            // initialize data in the test database
        }
    
        public void Dispose()
        {
            // clean up test data from the database
        }
    }
    //Class where you want to use shared class instance
    public class MyDatabaseTests : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture dbFixture;
    
        public MyDatabaseTests(DatabaseFixture fixture)
        {
            this.dbFixture = fixture;
        }
    
        // write tests, using dbFixture.Db to get access to the SQL Server
    }
