    [BsonIgnoreExtraElements]
    public class Payment
    {
        public ObjectId Id { get; set; }
        public decimal Amount { get; set; }
        public Type Type { get; set; }
    }
