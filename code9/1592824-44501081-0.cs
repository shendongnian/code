	public class GameData {
		public string gameId {get; set;}
		public int mapId {get; set;} //just demonstrating that it only fills in the fields you put in the model
		public List<Participant> participants = new List<Participant>();
	}
...
	public class Participant
    {
            public int profileIconId { get; set; }
            public int championId { get; set; }
            public string summonerName { get; set; }
            public bool bot { get; set; }
            public int spell2Id { get; set; }
            public int teamId { get; set; }
            public int spell1Id { get; set; }
            public int summonerId { get; set; }
    }
