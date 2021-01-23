    var client = new MongoClient();
    var database = client.GetDatabase("test");
    var collection = database.GetCollection<BsonDocument>("test");
    var changesJson = "{ a : 1, b : 2 }";
    var changesDocument = BsonDocument.Parse(changesJson);
    var filter = Builders<BsonDocument>.Filter.Eq("_id", 1);
    UpdateDefinition<BsonDocument> update = null;
    foreach (var change in changesDocument)
    {
        if (update == null)
        {
            var builder = Builders<BsonDocument>.Update;
            update = builder.Set(change.Name, change.Value);
        }
        else
        {
            update = update.Set(change.Name, change.Value);
        }
    }
    //following 3 lines are for debugging purposes only
    //var registry = BsonSerializer.SerializerRegistry;
    //var serializer = registry.GetSerializer<BsonDocument>();
    //var rendered = update.Render(serializer, registry).ToJson();
    //you can also use the simpler form below if you're OK with bypassing the UpdateDefinitionBuilder (and trust the JSON string to be fully correct)
    update = new BsonDocumentUpdateDefinition<BsonDocument>(new BsonDocument("$set", changesDocument));
    var result = collection.UpdateOne(filter, update);
