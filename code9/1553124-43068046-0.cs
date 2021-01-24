    public class Context
    {
        public const string DATABASE_NAME = "Test";
        public const string FIRST_COLLECTION_NAME = "FirstCollection";
        public const string SECOND_COLLECTION_NAME = "SecondCollection";
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;
        static Context()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDbServer"];
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }
        public IMongoClient Client => _client;
        public IMongoCollection<First> FirstCollection =>
            _database.GetCollection<First>(FIRST_COLLECTION_NAME);
        public IMongoCollection<Second> SecondCollection =>
            _database.GetCollection<Second>(SECOND_COLLECTION_NAME);
    }
