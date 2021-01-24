    `[Serializable]
    public class Account    {
        [NonSerialized]
        public string lastname;
        [JsonProperty("firstname")]
        public string firstName;
        [JsonProperty("curvingindex")]
        public int c5;
    }
