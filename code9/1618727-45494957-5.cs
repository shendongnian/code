    public class Person 
    {
        [JsonProperty(PropertyName = "id")]
        public string PersonId { get; set; }
    
        [JsonProperty(PropertyName = "firstName")]
        public string PersonFirstName { get; set; }
    
        [JsonConverter(typeof(MailAddressConverter))]
        [JsonProperty(PropertyName = "email")]
        public MailAddress PersonEmail { get; set; }
    }
