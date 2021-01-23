    public class UnitLog
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }
        public string Code { get; set; }
        public List<Unit> Units { get; set; }
    }
    
    public class Unit
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }
        
        public string Code { get; set; }
        public string Label { get; set; }
    }
