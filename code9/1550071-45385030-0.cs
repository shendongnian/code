    public class CdnDbContext
    {
        public IGridFSBucket GridFsBucket { get; set; }
        public CdnDbContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config.GetConnectionString("MongoCdn");
            var connection = new MongoUrl(connectionString);
            var settings = MongoClientSettings.FromUrl(connection);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(connection.DatabaseName);
            GridFsBucket = new GridFSBucket(database);
        }
    }
