    public ReadFromDB()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("test");
        var collectionWatchtbl = database.GetCollection<BsonDocument>("UserWatchtbl");
        var filter = new BsonDocument();
        var user = new List<UserWatchTblCls>();
        var cursor = collectionWatchtbl.FindAsync(filter).Result;
        cursor.ForEachAsync(batch =>
        {
            user.Add(BsonSerializer.Deserialize<UserWatchTblCls>(batch));
        });
    }
    public class UserWatchTblCls
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public string fbId { get; set; }
        public string Name { get; set; }
        [BsonElement("pass")]
        public string Pass { get; set; }
        [BsonElement("Watchtbl")]
        public List<WatchTblCls> WatchTbls { get; set; }
    }
    public class WatchTblCls
    {
        [BsonElement("wid")]
        public string WID { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("Symboles")]
        public List<SymboleCls> Symbols { get; set; }
    }
    public class SymboleCls
    {
        public string Name { get; set; }
    }
