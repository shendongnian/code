    public class Game
    {
        public Game(string homeTeamId, string visitorTeamId)
        {
            // Default Constructor
            GamePark = new Park();
            HomeTeam = new Team(homeTeamId);
            VisitorTeam = new Team(visitorTeamId);
        }
    
        // Reference Objects
        public DateTime Date { get; set; }
        public Park GamePark { get; set; }
        public Team HomeTeam { get; set; }
        public Team VisitorTeam { get; set; }
    
        // Value Objects
        public int HomeScore { get; set; }
        public int VisitorScore { get; set; }
        public string ParkId { get; set; }
        public int Attendance { get; set; }
    }
