    public long getLastTimestamp()
    {
        var filter = Builders<BsonDocument>.Filter.Exists("_id");
        return getChannelNames()
        .Select(channel => _database.GetCollection<BsonDocument>(channel.name).FindAsync(filter).Result.ToList())
        .Where(doc => !doc["_id"].IsObjectId)
        .Max(doc => doc["_id"].ToInt64);
    }
