    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }
    public class Class1
    {
        public string table { get; set; }
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public Rate[] rates { get; set; }
    }
    public class Rate
    {
        public string currency { get; set; }
        public string code { get; set; }
        public float mid { get; set; }
    }
