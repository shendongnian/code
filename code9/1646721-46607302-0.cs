    public class Version
    {
        public string value { get; set; }
        public string source-type { get; set; }
        public string source-id { get; set; }
        public string source-label { get; set; }
    }
    public class Firstname
    {
        public string value { get; set; }
        public IList<Version> versions { get; set; }
    }
    public class Person
    {
        public int id { get; set; }
        public Firstname firstname { get; set; }
    }
