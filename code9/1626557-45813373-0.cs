    private readonly MongoClient _mongoClient = new MongoClient("connectionString");
    public IMongoDatabase Database => _mongoClient.GetDatabase();
    private async Task<bool> CollectionExistsAsync(string collectionName)
    {
        var filter = new BsonDocument("name", collectionName);
        //filter by collection name
        var collections = await _mongo.Database.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });
        //check for existence
        return await collections.AnyAsync();
    }
    var oldSmsLogExists = await CollectionExistsAsync("RrenameCollection").ConfigureAwait(false);
    if (oldSmsLogExists)
        _mongo.Database.RenameCollection("RrenameCollection", "RenameCollection");
