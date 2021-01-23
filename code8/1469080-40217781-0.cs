    public class Player
    {
        // Static list keeping all your instances
        public static List<Player> players = new List<Player>();
        // Constructor
        public Player(/* Your different parameters */)
        {
            // Your class initialization
            players.Add(this);
        }
        // Rest of your class definition
    }
