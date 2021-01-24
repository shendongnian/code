    public class Person
    {
        public string User { get; set; } //Maps to { "User" : "value" }
        public int Age { get; set; }    //Maps to { "Age" : value }
        public List<string> Hobby { get; set; } //Maps to { ["value1","value2","..."] }
    }
