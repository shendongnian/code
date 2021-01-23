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
