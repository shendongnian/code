    public class Player
    {
        public string playerId { get; set; }
        public string name { get; set; }
        public string position { get; set; }
    }
    
    var teams = JsonConvert.DeserializeObject<Dictionary<string, List<Player>>>(jsonContent);
    List<Player> players = teams.SelectMany(kvp => kvp.Value);
