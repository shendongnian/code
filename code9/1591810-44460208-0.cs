    internal sealed class TestConfiguration : DbMigrationsConfiguration<TestContext>
    {
        public TestConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TestContext";
            this.SetSqlGenerator("System.Data.SqlClient", new 
            TestSqlServerMigrationSqlGenerator());
        }
    }
    
