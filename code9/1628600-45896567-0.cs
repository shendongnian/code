    public class Games
    {
        public Game[] titles { get; set; }
    }
    public class Game
    {
       
        public string name { get; set; }
        public string gamertag { get; set; }
        public string platform { get; set; }
        public int earnedAchievements { get; set; }
        public string currentGamerscore { get; set; }
        public string maxGamerscore { get; set; }
        public string lastUnlock { get; set; }
    }
