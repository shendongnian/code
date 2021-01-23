    MongoReadData_ResponseTEST<RocketResponse>(Mongo_ListOfFieldsToDisplay_RocketResponse, "RocketResponse", "RocketResponseId");
    MongoReadData_ResponseTEST<RocketRequest>(Mongo_ListOfFieldsToDisplay_RocketRequest, "RocketRequest", "RocketRequestId");
    public static int MongoReadData_ResponseTEST<T>(string[] MongoListOfFieldsToDisplay, string CollectionName, string PKToSearchOn) where T : class, new()
    {
        int CountRecords = 0;
        // create connection TO MongoDB
        MongoClient MongoClientConn = new MongoDatabaseConnection().mongoConn();
        var MongoDB = MongoClientConn.GetDatabase("Viper");
        var collection = MongoDB.GetCollection<T>(CollectionName);
        var filter = Builders<T>.Filter.Eq(PKToSearchOn, 4);
        //var filter = Builders<RocketRequest>.Filter.Empty;
        var result = collection.Find(filter).ToListAsync().Result;
        // do here so it is after the filtering
        CountRecords = Convert.ToInt32(collection.Find(filter).Count());
        return CountRecords;
    }// end MongoReadData    
