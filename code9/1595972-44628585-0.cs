    public class IdentityConfigurationDbContextFactory : IDbContextFactory<IdentityConfigurationDbContext> {
    
            public IdentityConfigurationDbContext Create(DbContextFactoryOptions options) {
                var optionsBuilder = new DbContextOptionsBuilder<ConfigurationDbContext>();
                var config = new ConfigurationBuilder()
                                 .SetBasePath(options.ContentRootPath)
                                 .AddJsonFile("appsettings.json")
                                  .AddJsonFile($"appsettings.{options.EnvironmentName}.json", true)
    
                                 .Build();
    
                optionsBuilder.UseOracle(config.GetConnectionString("DefaultConnection"));
    
                return new IdentityConfigurationDbContext(optionsBuilder.Options, new ConfigurationStoreOptions());
            }
        }
