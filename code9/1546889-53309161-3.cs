    public class TestContextFactory : IContextFactory
        {
            public MyDBCoreDBEntities CreateNew()
            {
                var connectionString = "sampleConnString";
                var con = Effort.EntityConnectionFactory.CreatePersistent(connectionString);
                return new MyDBCoreDBEntities(con);
            }
    
        }
    
