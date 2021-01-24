    public class Person {
        public string name { get; set; }
        public string surname { get; set; }
    }
    public class Friend {
        public string name { get; set; }
        public string surname { get; set; }
    }
    public class DataModel {
        public int id { get; set; }
        public Person person { get; set; }
        public IList<string> qualities { get; set; }
        public IList<Friend> friends { get; set; }
    }
