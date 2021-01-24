    public class ResponseType
    {
        public RootObject MyRootObject{ get; set; }
    }
    public class RootObject
    {
        public int msec { get; set; }
        public Request request { get; set; }
        public string __class__ { get; set; }
        public List<Result> results { get; set; }
    }
