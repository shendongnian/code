    public class Exception
    {
       [JsonProperty(PropertyName = "$id")]
       public string id { get; set; }
       public object innerException { get; set; }
       public string message { get; set; }
       public string typeName { get; set; }
       public string typeKey { get; set; }
       public int errorCode { get; set; }
       public int eventId { get; set; }
    }
