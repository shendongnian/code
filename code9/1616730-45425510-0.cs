    IMongoClient client = new MongoClient();
    IMongoDatabase db = client.GetDatabase("MyDB");
    // create collection calls are not needed, MongoDB will do that for you
    // db.CreateCollection("ObjectList1");
    var objectList1Collection = db.GetCollection<ObjectClass1>("ObjectList1");
    objectList1Collection.InsertMany(ObjectList1);
