    public class RootObject
    {
        public Json json { get; set; }
    }
    public class Json
    {
        public List<object> errors { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public bool need_https { get; set; }
        public string modhash { get; set; }
        public string cookie { get; set; }
    }
