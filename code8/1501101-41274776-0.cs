    public class ExampleGroup 
    {
        [BsonId]
        public ObjectId Id {get;set;}
        public string SomeStringField { get; set; }
        public int SomeNumberField {get; set;}
    }
