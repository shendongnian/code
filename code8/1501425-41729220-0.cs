    public class RequestModel 
    {
       [JsonProperty("queryStringParameters")]
       public Dictionary<string, string> QueryStringParameters { get; set; }
    }
