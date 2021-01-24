    public class ContextFactory : IContextFactory
        {
            public string ConnectionString { get; set; }
            public ContextFactory(string connectionString)
            {
                ConnectionString = CreateEFConnectionString(connectionString, RepositoryConst.EdmxName);
            }
    
            public MyDBCoreDBEntities CreateNew()
            {
                return new MyDBCoreDBEntities(ConnectionString);
            }
        }
