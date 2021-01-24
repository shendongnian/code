    public partial class Contact
    {
        // Initial properties as before.
        [JsonProperty("emails")]
        public Email[] Emails { get; set; }
        // Other properties as before
    }
    public class Email
    {
        [JsonProperty("email")]
        public string EmailValue { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
