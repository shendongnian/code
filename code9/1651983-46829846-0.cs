    public class Result
    {
        public string name { get; set; }
        public string alpha2_code { get; set; }
        public string alpha3_code { get; set; }
    }
    
    public class RestResponse
    {
        public List<string> messages { get; set; }
        public Result result { get; set; }
    }
    
    public class Country
    {
        public RestResponse RestResponse { get; set; }
    }
