    MongoClient mongoClient = new MongoClient(mongoConnString);
    IMongoDatabase mdb = mongoClient.GetDatabase(dbName);
    IMongoCollection<MyCollection> coll = mdb.GetCollection<MyCollection>(myCollection);
    
    var sort = Builders<MyCollection>.Sort.Descending("_id");
    var filter1 = Builders<MyCollection>.Filter.Empty;
    var filter2 = Builders<MyCollection>.Filter.Eq("value", "myValue");
    
    /* 1 */ var results = coll.Find(filter1).Sort(sort).Limit(10);
    /* 2 */ var results = coll.Find(filter2).Sort(sort).Limit(10);
