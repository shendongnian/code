        public void doIt<T>()
        {
        services.AddScoped<IRepository<T>>(x => new DocumentDbRepository<T>(
    new DatabaseSettings(Configuration.GetSection("DocumentDb").GetSection("DatabaseName").Value, 
    Configuration.GetSection("DocumentDb").GetSection("CollectionName").Value, 
    Configuration.GetSection("DocumentDb").GetSection("EndpointUri").Value, 
    Configuration.GetSection("DocumentDb").GetSection("Key").Value)));
        }
