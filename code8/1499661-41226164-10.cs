    public class Game
    {
        public string Wins { get; set; } // you may want to check this string here ;)
        public int Lost { get; set; }
        public string Played { get; set; }
    }
    public class Games
    {
        public Game Quick { get; set; }
    	public Game Competitive { get; set; }
	}
