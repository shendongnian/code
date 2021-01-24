    public class SqlServerTenantDbContextFactory : IDbContextFactory
    {
       TDbContext IDbContextFactory.CreateDbContext<TDbContext>()
       {
          return (TDbContext)Activator.CreateInstance<TDbContext>();
       }
    
       TDbContext IDbContextFactory.CreateDbContext<TDbContext>(IDbTenant tenant)
       {
          var connection = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
          // based on the provider set up in <providers> configration under <entityFramework>...
          connnection.ConnectionString = tenant?.ConnectionString;
          return (TDbContext)Activator.CreateInstance(typeof(TDbContext), tenant, connection, true);
       }
       
    
       TDbContext IDbContextFactory.CreateDbContext<TDbContext>(string connectionString)
       {
          var connection = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
          connnection.ConnectionString = connectionString;
          return (TDbContext)Activator.CreateInstance(typeof(TDbContext), connection, true);
       }
    }
