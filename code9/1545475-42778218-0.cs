    public class Obj
    {
        [JsonProperty(PropertyName = "link")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "title")]
        public Title Title { get; set; }
    }
    public class Title 
    {
        [JsonProperty(PropertyName = "rendered")]
        public class Rendered { get; set; }
    }
    // Usage:
    Console.WriteLine(obj.Url); 
    Console.WriteLine(obj.Title.Rendered);
