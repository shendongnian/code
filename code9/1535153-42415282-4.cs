    public class JsonRoot
    {
        [JsonProperty("$id")]
        public string Id_X { get; set; }
        [JsonProperty("$type")]
        public string Type_X { get; set; }
        public bool UploadedToDatabase { get; set; }
        public string Id { get; set; }
        public bool TournamentStarted { get; set; }
        public int MaximumNumberOfRounds { get; set; }
        public string Name { get; set; }
        public League[] Leagues { get; set; }
        public object SaveFilePath { get; set; }
        public object SavedFileName { get; set; }
        public object DefaultPairingMethod { get; set; }
        public int DefaultPairingLag { get; set; }
        public bool IsTournamentRanked { get; set; }
        public string UserId { get; set; }
        public object StreamUrl { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int NumberOfPlacesForPrizes { get; set; }
        public bool isTournamentDirector { get; set; }
    }
