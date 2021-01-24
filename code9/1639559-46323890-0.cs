    public class Last5Match
    {
            public List<Match> HomeTeamMatches { get; set; } = new List<Match>(5);
            public List<Match> AwayTeamMatches { get; set; } = new List<Match>(5);
            public string HomeTeamName { get; set; }
            public string AwayTeamName { get; set; }
            public List<Match> TotalMatches
            {
               get{ return HomeTeamMatches.Union(AwayTeamMatches).ToList(); }
            }
        }
