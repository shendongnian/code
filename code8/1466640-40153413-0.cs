    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class MyClass
    {  
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }
    }
