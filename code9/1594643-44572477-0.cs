    using Newtonsoft.Json;
    public class Person
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        
        ...
    }
