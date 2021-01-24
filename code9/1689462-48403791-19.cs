    public class Record
    {
        [BsonId]    
        public ObjectId _id { get; set; }
        public string ID { get; set;}
        public string URL {get; set;}
        public string Refer {get; set;}
        public string Category { get; set; }
    }
