    public class Response
    {
        public int status { get; set; }
        public int httpStatus { get; set; }
        public Dictionary<string,Data> data { get; set; }
        public object[] errors { get; set; }
        public object errorMessage { get; set; }
    }
