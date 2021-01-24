    public class Game
        {
            public static List<Participant> Participants = new List<Participant>();
            public static List<SummonerStats> SummonerStatsList = new List<SummonerStats>();       
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            lstSummonerStats.DataSource = Game.SummonerStatsList.Select(x => x.PropertyName).ToList();
        }
