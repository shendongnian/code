    namespace DL.STS.Host
    {
        public class Startup
        {
            ...
            public void ConfigureServices(IServiceCollection services)
            {
                string connectionString = _configuration.GetConnectionString("appDbConnection");
                string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly
                    .GetName().Name;
                services
                   .AddIdentityServer()
                   .AddConfigurationStore(options =>
                   {
                       options.ConfigureDbContext = builder =>
                           // I made up this extension method "UseOracle",
                           // but this is where you plug your database in
                           builder.UseOracle(connectionString,
                               sql => sql.MigrationsAssembly(migrationsAssembly));
                   })
                   ...;
 
                ...
            }
            ...
        }
    }
