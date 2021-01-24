     public partial class HttpGetResponse
    {
        [JsonProperty("StatusCode")]
        public string StatusCode { get; set; }
        [JsonProperty("ResponseMessage")]
        public string ResponseMessage { get; set; }
        [JsonProperty("Payload")]
        public Payload Payload { get; set; }
    }
    public class Payload
    {
        public string Address { get; set; }
        public string City { get; set; }
    }
