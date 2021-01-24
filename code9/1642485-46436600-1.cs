    public class MyClass
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        [JsonIgnore]
        public List<MyObject> MyObjectLists { get; set; }
    }
