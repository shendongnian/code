    public class Obj
    {
        [JsonProperty(PropertyName = "link")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "title")]
        public Dictionary<string, string> Title { get; set; }
    }
    // Usage:
    Console.WriteLine(obj.Url); 
    Console.WriteLine(obj.Title["rendered"]); 
