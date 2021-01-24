    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        [BsonDictionaryOptions(DictionaryRepresentation.Document)]
        public Dictionary<string, Object> OtherData { get; set; }
    }
