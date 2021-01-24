    public class Player
    {
            public string Name { get; set; }
            public int Score { get; set; }
    }
    public int Count
    public List<Player> Players
    public HighScore()
    {  
      Players = new List<Player>();
    }
    //your initialize
    public static void Initialize()
    {
       string fullpath = "";
       HighScore data;
 
       if (!File.Exists(fullpath))
       {
                
                Player player = new Player { Name = "Neil", Score = 20 };
                Player player1 = new Player { Name = "Shawn", Score = 15 };
                Player player2 = new Player { Name = "Mark", Score = 10};
                Player player3 = new Player { Name = "Cindy", Score = 5 };
                Player player4 = new Player { Name = "Sam", Score = 1 };
                data.Players.Add(player);
                data.Players.Add(player1);
                data.Players.Add(player2);
                data.Players.Add(player3);
                data.Players.Add(player4);
               
                SaveHighScores(data, fullpath);
       }
    }
     public static void SaveHighScore(int score, string name)
     {
            HighScore data = LoadHighScores(HighScoresFilename);
            var player = data.Players.FirstOrDefault(x => x.Name == "Vincent");
            // new player in town
            if(player == null)
            {
                Player newPlayer = new Player { Name = "Vincent", Score = score };
                data.Players.Add(newPlayer);
                data.Players = data.Players.OrderByDescending(o=>o.Score).ToList();
            }
            else
            {
                //set new score
                player.Score = score;
                data.Players = data.Players.OrderByDescending(o => o.Score).ToList();
            }
            
            data.Count = data.Players.Count;
            SaveHighScores(data, HighScoresFilename);
    }
