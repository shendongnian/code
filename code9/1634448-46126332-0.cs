    class Player
    {
        public string Name { get; }
        public int Rating { get; set; }
        public Player(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }
    }
    
    static class Game
    {
        static void Play(Player player1, Player player2)
        {
            // code to play the game here, also sets player1NewRating and player2NewRating
        
            player1.Rating = player1NewRating;
            player2.Rating = player2NewRating;
        }
        
        static void Main()
        {
            var bob = new Player("Bob", 1000);
            var joe = new Player("Joe", 1200);
        
            Play(bob, joe);
        }
    }
