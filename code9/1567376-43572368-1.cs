    public class PlayerScores : IPlayerScores
    {
        public PlayerScores(string points, string price)
        {
            this.Points = points;
            this.Price = price;
        }
    
        public string Points { get; set; }
        public string Price { get; set; }
    }
