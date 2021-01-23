    public class Model
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime startDate { get; set; }
    }
