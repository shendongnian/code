    public class Game
    {
        [JsonProperty("$id")]
        public string ID_X { get; set; }
        [JsonProperty("$type")]
        public string Type_X { get; set; }
        public object Parent { get; set; }
        public bool UploadedToDatabase { get; set; }
        public string Id { get; set; }
        public int TableNumber { get; set; }
        public string PlayerOneId { get; set; }
        public string PlayerTwoId { get; set; }
        public object PlayerOne { get; set; }
        public object PlayerTwo { get; set; }
        public int PlayerOneScore { get; set; }
        public int PlayerTwoScore { get; set; }
        public object HighestScoringWord { get; set; }
        public string ScoresSubmittedDateTime { get; set; }
    }
----------
    public class Player
    {
        [JsonProperty("$id")]
        public string ID_X { get; set; }
        [JsonProperty("$type")]
        public string Type_X { get; set; }
        public bool UploadedToDatabase { get; set; }
        public string Id { get; set; }
        public object Parent { get; set; }
        public List<Game> Games { get; set; }
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public object Username { get; set; }
        public object Email { get; set; }
        public double Rating { get; set; }
        public int PointsFor { get; set; }
        public int PointsAgainst { get; set; }
        public double NumberOfWins { get; set; }
        public double NumberOfDraws { get; set; }
        public double NumberOfLosses { get; set; }
        public int Spread { get; set; }
        public string FullName { get; set; }
        public bool IsSelected { get; set; }      
    }
