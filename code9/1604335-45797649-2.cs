    public class EventReg
    {
        public EventReg()
        {
           FormFields = new ExpandoObject();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventRegId { get; set; }
    
        [BsonElement("event_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventId { get; set; }
    
        [BsonElement("user_email")]
        public string UserEmail { get; set; }
    
        [BsonElement("reg_time")]
        public DateTime RegTime{ get; set; }
        
        [BsonElement("form_fields")]
        public ExpandoObject FormFields { get; set; }
    }
