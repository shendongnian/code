    public class Player
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nickname { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string sex { get; set; }
        [JsonProperty]
        public Address address { get; set; }
        public List<string> email { get; set; }
        public List<string> phone { get; set; }
    }
