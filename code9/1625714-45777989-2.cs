    class Program
    {
        static void BetterMain(string[] args)
        {
            List<TeamV2> teamList = new List<TeamV2>();
            foreach(var team in teamList)
            {
                List<Player> starters = team.playerList.Where(p => p.isStarter == true).ToList();
                starters.ForEach(p => Console.WriteLine(p.positionName));
            }        
        }
    }
    public class TeamNeeds
    {
        public string QB { get; set; }
        public string RB { get; set; }
        public string WR { get; set; }
        public string TE { get; set; }
    }
    public class TeamV2
    {
        public List<Player> playerList = new List<Player>();
    }
    public class Player
    {
        public bool isStarter;
        public bool positionName;
    }
