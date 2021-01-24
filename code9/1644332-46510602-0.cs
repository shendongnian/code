    public class Result
    {
        public bool success { get; set; }
        public string message { get; set; }
        public int errorcode { get; set; }
    }
    public class Response
    {
        public string id { get; set; }
        public string full_name { get; set; }
        public string mobile_no { get; set; }
        public object phone_no { get; set; }
        public string country_code { get; set; }
        public string country_of_residence { get; set; }
        public string email { get; set; }
        public string passport_no { get; set; }
    }
    public class RootObject
    {
        public Result result { get; set; }
        public Response response { get; set; }
    }
    
