    public class SomeClass {
    
        [BsonId]
        public ObjectId MySuperId { get; set; }
    
        public Something() {
            this.MySuperId = ObjectId.GenerateNewId();
        }
    
    }
