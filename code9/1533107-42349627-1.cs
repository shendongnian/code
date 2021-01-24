    public class SomeClass {
    
        [BsonId]
        public ObjectId MySuperId { get; set; }
    
        public SomeClass() {
            this.MySuperId = ObjectId.GenerateNewId();
        }
    
    }
