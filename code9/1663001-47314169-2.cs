    public class MyClass
    {
        public string Id { get; set; }
        [BsonRepresentation(BsonType.String)] 
        public List<MyEnum> Values { get; set; }
    }
