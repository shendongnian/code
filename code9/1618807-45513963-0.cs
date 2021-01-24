    var collection = db.GetCollection<BsonDocument>("MyCollection");                              
    //Hard coded for testing
    var filter = Builders<BsonDocument>.Filter.Eq("ListingKey", "234534345345");
    var update = Builders<BsonDocument>.Update.Set("Created", DateTime.UtcNow);
    foreach (BsonElement item in document)
    {
        update = update.Set(item.Name, item.Value);
    }
    var result = collection.UpdateOne(filter, update);
