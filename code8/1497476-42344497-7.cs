    using System.Data.SqlClient;
    
    namespace MyLibrary.DataAccessors
    {
        public class DatabaseConnectionFactory : IDatabaseConnectionFactory
        {
    
            private readonly DataStoreConfiguration dataStoreConfiguration;
    
            public DatabaseConnectionFactory(
                DataStoreConfiguration dataStoreConfiguration)
            {
                // Here we inject a concrete instance of DataStoreConfiguration
                // without the `IOption` wrapper.
                this.dataStoreConfiguration = dataStoreConfiguration;
            }
    
            public SqlConnection NewConnection()
            {
                return new SqlConnection(dataStoreConfiguration.ConnectionString);
            }
        }
    }
