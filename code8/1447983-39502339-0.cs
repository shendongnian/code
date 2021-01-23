    public class AccountDetailsViewModel
    {
        public string AccountId { get; set; }
        public IVRS m_newIVR { get; set; }
    }
    public class IVRS
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("account")]
        public string Account { get; set; }
    }
    
