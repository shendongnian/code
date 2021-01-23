    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
    
    namespace MyNamespace
    {
        public class MyContext : DbContext
        {
            public MyContext(DbContextOptions<MyContext> options) : base(options)
            {
                var sqlServerOptionsExtension = 
                       options.FindExtension<SqlServerOptionsExtension>();
                if(sqlServerOptionsExtension != null)
                {
                    string connectionString = sqlServerOptionsExtension.ConnectionString;
                }
            }
        }
    }
