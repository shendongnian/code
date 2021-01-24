    public class SyncContact
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
