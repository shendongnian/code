    public class Record
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }
        public string SKU { get; set;}
        public string Purchase {get; set;}
        public string Slider {get; set;}
        public string Category { get; set; }
    }
