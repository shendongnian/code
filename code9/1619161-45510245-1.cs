    using Newtonsoft.Json;
    
    public class Person {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("fullName")]
        public string FullName => FirstName + " " + LastName;
    
        [JsonIgnore]
        public string FirstName { get; set; }
    
        [JsonIgnore]
        public string LastName { get; set; }
    }
