    public static class DalServiceCollectionExtensions
    {
        public static IServiceCollection AddDALDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<MongoSettings>(s =>
            {
                s.Database = configuration.GetSection("MongoConnection:Database").Value;
            });
            
            services.AddSingleton<IMongoClient, MongoClient>(
                client => new MongoClient(configuration.GetSection("MongoConnection:ConnectionString").Value));
            return services;
        }
    }
