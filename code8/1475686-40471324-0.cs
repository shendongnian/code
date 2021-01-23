    [BsonIgnoreExtraElements]
    public class Tweet
    {
        public ObjectId Id { get; set; }
        [BsonElement("text")]
        public string Texto { get; set; }
        [BsonElement("created_at")]
        [BsonSerializer(typeof(FechaTweetsSerializer))]
        public DateTime Fecha { get; set; }
    }
