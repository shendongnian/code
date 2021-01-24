    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace DL.STS.Data.ConfigurationStore.EFCore.Extensions
    {
        public static class IdentityServerBuilderExtensions
        {
            public static IIdentityServerBuilder AddEFConfigurationStore(
                this IIdentityServerBuilder builder, string connectionString)
            {
                string assemblyNamespace = typeof(AppConfigurationDbContext).Namespace;
    
                builder.AddConfigurationStore<AppConfigurationDbContext>(options =>
                    options.ConfigureDbContext = b =>
                        b.UseSqlServer(connectionString, optionsBuilder =>
                            optionsBuilder.MigrationsAssembly(assemblyNamespace)
                        )
                );
    
                return builder;
            }
        }
    }
        
