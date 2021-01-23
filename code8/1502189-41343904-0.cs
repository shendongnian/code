     static void Main(string[] args)
            {
    
                var connectionString = "mongodb://localhost:27017/dbtest?readPreference=primary";
                var mongoUrl = new MongoUrl(connectionString);
                var client = new MongoClient(mongoUrl);
                var database = client.GetDatabase(mongoUrl.DatabaseName);
    
                var collection = database.GetCollection<BsonDocument>("Documents");
    
                collection.InsertOne(new BsonDocument("Key1", new BsonDocument("subKey1", "subValue1")));
                collection.InsertOne(new BsonDocument("Key2", "Value2"));
                collection.InsertOne(new BsonDocument("Key3", "Value3"));
    
    
    
                Console.WriteLine(collection.Count(FilterDefinition<BsonDocument>.Empty));
                Console.ReadLine();
            }
