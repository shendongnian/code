    public class Rootobject
    {
        public Datum[] data { get; set; }
        public int duration { get; set; }
        public string query { get; set; }
        public int timeout { get; set; }
    }
    public class Datum
    {
        public string name { get; set; }
        public int pwd { get; set; }
    }
