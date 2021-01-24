    public class PostalCode // Bit like a zipcode
    {
        [JsonProperty(PropertyName = "PostalCode")]
        public string Value { get; set; }
   
        // Maybe sprinkle some ToString()/Equals() overrides here
    }
