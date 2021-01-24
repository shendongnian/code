     public class Example
    {
        public string status { get; set; }
        public IList<IList<Datum>> data { get; set; }
        public string msg { get; set; }
    }
    public class Datum
    {
        public object value { get; set; }
        public string key { get; set; }
    }
