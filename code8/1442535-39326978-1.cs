    public class RootObject
    {
        public class GameStats
        {
            private GameStats() { }
            //Code omitted
        }
        public class Request
        {
            private Request() { }
            //Code omitted
        }
        public class AverageStats
        {
            private AverageStats() { }
            //Code omitted
        }
        public class OverallStats
        {
            private OverallStats() { }
            //Code omitted
        }
        public Request _request { get; set; }
        public AverageStats average_stats { get; set; }
        public string battletag { get; set; }
        public GameStats game_stats { get; set; }
        public OverallStats overall_stats { get; set; }
        public string region { get; set; }
    }
