        public static class DalServiceCollectionExtensions
        {
            public static IServiceCollection AddDALDependencies(this IServiceCollection services, IConfigurationRoot configuration)
            {
                services.Configure<MongoSettings>(s =>
                {
                    s.Database = Configuration.GetSection("MongoConnection:Database").Value;
                });
                services.AddSingleton<IMongoClient, MongoClient>(client => new MongoClient(Configuration.GetSection("MongoConnection:ConnectionString").Value));
                return services;
            }
        }
