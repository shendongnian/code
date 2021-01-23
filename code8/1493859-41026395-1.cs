    public class Name
    {
        [JsonProperty(PropertyName = "First Name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "Last Name")]
        public string LastName { get; set; }
    }
    
    public class RootObject
    {
        public List<Name> Name { get; set; }
    }
