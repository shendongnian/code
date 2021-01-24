    public class Rootobject2
    {
        public int id { get; set; }
        public string userName { get; set; }
        public IDictionary<string, NameValuePair> tags { get; set; }
    }
    public class NameValuePair
    {
        public string name { get; set; }
        public string value { get; set; }
    }
