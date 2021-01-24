    using System.Data.Common;
    using System.Data.Entity;
    
    namespace MC.ClientApi.CompanyProfile.Repository
    {
        public partial class MyDBCoreDBEntities : DbContext
        {
            public MyDBCoreDBEntities(string connectionString)
                : base(connectionString)
            {
            }
            public MyDBCoreDBEntities(DbConnection connection) : base(connection, true) { }
        }
    }
