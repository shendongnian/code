    public class Response
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
    }
    public class Data
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
    public class Error
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class Example
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
