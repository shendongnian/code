    public class Rootobject
    {
        public int totalNumberOfAchievements { get; set; }
        public int numberOfAchievementsCompleted { get; set; }
        public string finishedAchievements { get; set; }
        public Achievement[] achievements { get; set; }
    }
    public class Achievement
    {
        public string name { get; set; }
        public bool finished { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string category { get; set; }
    }
