    public IEnumerable<T> GetMongoData<T>(string collectionName, 
                                Expression<Func<T,bool>> filter)
    {
        MongoClient MongoClientConn = new MongoDatabaseConnection().mongoConn();
        var MongoDB = MongoClientConn.GetDatabase("Viper");
        var collection = MongoDB.GetCollection<T>(collectionName);
    
        return collection.Find(filter).ToEnumerable();
    }
