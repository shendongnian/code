    public abstract class MongoDatabase
    {
        private readonly IConfigurationRepository _configuration;
        private readonly IMongoClient Client;
        private readonly IMongoDatabase Database;
        protected MongoDatabase()
        {
            //_configuration = configuration;
            var connection = "mongodb://host:27017";
            var database = "test";
            this.Client = new MongoClient();
            this.Database = this.Client.GetDatabase(database);
        }
        public List<T> GetEntityList<T>()
        {
            return GetCollection<T>()
                    .Find(new BsonDocument()).ToList<T>();
        }        
        public IMongoCollection<T> GetCollection<T>()
        {
            return this.Database.GetCollection<T>(typeof(T).FullName);
        }
    }
