    `[Serializable]
    public class Account    {
        [NonSerialized]
        public string lastname;
        [JsonProperty("firstname")]
        public string firstName;
        [JsonProperty("index")]
        public int c5;
    }
