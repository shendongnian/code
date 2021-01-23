    public async Task<bool> CheckCollection(IMongoDatabase database, string collectionName)
    {
        var filter = new BsonDocument("name", collectionName);
        var collectionCursor = await database.ListCollectionsAsync(new ListCollectionsOptions {Filter = filter});
        return await collectionCursor.AnyAsync();
    }
