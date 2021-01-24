    public class Game
    {
        public static List<Participant> Participants = new List<Participant>();
        public static List<SummonerStats> SummonerStatsList = new List<SummonerStats>();
        public static List<string> GetSummonerStats()
        {
            return SummonerStatsList.Select(x => x.PropertyName).ToList();
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        lstSummonerStats.DataSource = Game.GetSummonerStats();
    }
