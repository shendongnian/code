    public class MyClass
    {
        public string ClassName { get; set; }
        public string Teacher { get; set; }
        public int Student { get; set; }
        public int Aircond { get; set; }
        public IDictionary<string, object> Assets { get; set; }
    }
    var myClass = JsonConvert.DeserializeObject<MyClass>(json);
