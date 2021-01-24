    static void Main(string[] args)
    
    {
        var client = new MongoClient("mongodb://10.X.X.X:27017");
        var database = client.GetDatabase("MyDataBase");
        var myCollection = database.GetCollection<BsonDocument>("MyCollectionName");
        var document = new MyClass
        {
            ProductID = new MongoDBRef("Product", new ObjectId("k9ff635f18fg12c56hjf3fae")),
            className = "name",
            classNum = 21
        };
        myCollection.InsertOne(document.ToBsonDocument());
    }
