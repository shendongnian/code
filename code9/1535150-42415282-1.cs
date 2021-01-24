    public class League
    {
        [JsonProperty("$id")]
        public string ID_X { get; set; }
        [JsonProperty("$type")]
        public string Type_X { get; set; }
        public bool UploadedToDatabase { get; set; }
        public string Id { get; set; }
        public object Name { get; set; }
        public int NumberOfRounds { get; set; }
        public object Parent { get; set; }
        public Player[] Players { get; set; }
        public Round[] Rounds { get; set; }
        public bool LeagueStarted { get; set; }
        public object Prizes { get; set; }
    }
----------
    public class Round
    {
        [JsonProperty("$id")]
        public string ID_X { get; set; }
        [JsonProperty("$type")]
        public string Type_X { get; set; }
        public bool UploadedToDatabase { get; set; }
        public string Id { get; set; }
        public object Parent { get; set; }
        public List<Game> Games { get; set; }
        public bool HasStarted { get; set; }
        public string TimeStarted { get; set; }
        public int RoundNumber { get; set; }
    }
