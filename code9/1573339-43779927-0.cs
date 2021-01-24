    public class Datum
    {
        public string code { get; set; }
        public string findex { get; set; }
    }
    
    public class RootObject
    {
        public string sr_no { get; set; }
        public List<Datum> data { get; set; }
    }
