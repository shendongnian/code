    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.SqlServer;
    
    namespace ProjectName.MSSQL
    {
        public class MSSQLDbConfiguration:DbConfiguration
        {
            public MSSQLDbConfiguration()
            {
                this.SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
                this.SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
            }
        }
    }
