    MongoClient _client;
    IMongoDatabase _db;
    public DataAccess()
    {
        _client = new MongoClient("mongodb://localhost:27017");
        _db = _client.GetDatabase("Users");
    }
