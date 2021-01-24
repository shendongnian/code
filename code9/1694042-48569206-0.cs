    public class Payload
    {
        public string Address { get; set; }
        public string City { get; set; }
    }
    
    public class HttpGetResponse
    {
        public string StatusCode { get; set; }
        public string ResponseMessage { get; set; }
        public Payload Payload { get; set; }
    }
