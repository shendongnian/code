    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddDbContext<SomeContext>(options => options.UseSqlite(connectionString, b => b.MigrationsAssembly("ExternalEntityFramework")));
            return services;
        }
    }
