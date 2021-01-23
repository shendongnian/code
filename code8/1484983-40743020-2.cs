    public class Team
    {
        public Team(string teamId)
        {
            TeamId = teamId;
            TeamsLeague = new League();
        }
    
        public string TeamId { get; set; }
        public League TeamsLeague { get; set; }
        public string Name { get; set; }
    }
