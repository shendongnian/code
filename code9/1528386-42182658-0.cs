    public MongoDatabase()
    {
       _client = new MongoClient(_connectionString);
       _db = _client.GetDatabase(_dbName);
    }
