    public class Version
    {
        public string Value { get; set; }
        public string Source-type { get; set; }
        public string Source-id { get; set; }
        public string Source-label { get; set; }
    }
    public class Firstname
    {
        public string Value { get; set; }
        public IList<Version> Versions { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public Firstname Firstname { get; set; }
    }
