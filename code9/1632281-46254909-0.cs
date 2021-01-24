    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class MongoBaseDocument
    {
        public BsonObjectId Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        [BsonIgnore]
        [JsonIgnore]
        public bool IsNewEntity => Id == null || Id == BsonObjectId.Empty;
    }
