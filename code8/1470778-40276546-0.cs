    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
    }
    public class Response
    {
        public Result result { get; set; }
        public string uri { get; set; }
        public Error error { get; set; }
    }
    public class RootObject
    {
        public Response response { get; set; }
    }
