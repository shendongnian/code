    public class ScoreboardResults
    {
        public int timestamp { get; set; }
        public int total_players { get; set; }
        public int max_score { get; set; }
        public Dictionary<string, Player> players { get; set; }
    }
