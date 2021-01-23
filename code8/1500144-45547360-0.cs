    // add user into datagridview from MongoDB Colelction Watchtbl
    var client = new MongoClient("mongodb://dataservername:27017");
    var database = client.GetDatabase("WatchTblDB");
    var collectionWatchtbl = database.GetCollection<BsonDocument>("UserWatchtbl");
    var filter = new BsonDocument();
    var users = new List<UserWatchTblCls>();
    var cursor = collectionWatchtbl.FindAsync(filter).Result;
    cursor.ForEachAsync(batch =>
    {
        users.Add(BsonSerializer.Deserialize<UserWatchTblCls>(batch));
    });
    foreach (var user in users)
    {
        List<WatchTblCls> removables = new List<WatchTblCls>();
        foreach (var watchTbl in user.WatchTbls)
            if (string.IsNullOrEmpty(watchTbl.WID) && string.IsNullOrEmpty(watchTbl.Name) && watchTbl.Symbols.Count == 1 && string.IsNullOrEmpty(watchTbl.Symbols.Single().Name))
                removables.Add(watchTbl);
        foreach (WatchTblCls removable in removables)
            user.WatchTbls.Remove(removable);
        collectionWatchtbl.UpdateOne(Builders<BsonDocument>.Filter.Eq("_id", user.Id), Builders<BsonDocument>.Update.Set("Watchtbl", user.WatchTbls));
    }
