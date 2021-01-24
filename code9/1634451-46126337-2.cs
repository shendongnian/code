    // Keep a dictionary of all players
    Dictionary<string, Player> PlayerDict = new Dictionary<string, Player>();
    public void addNewPlayer(string newPlayerName)
    {
        // create new player with rating of 0
        Player newPlayer = new Player(newPlayerName, 0);
        // check if the player already exists in dictionary
        if (!PlayerDict.ContainsKey(newPlayer.name))
        {
            // player doesn't exist / add player
            PlayerDict.Add(newPlayer.name, newPlayer);
        }
    }
    public void changePlayerRating(String name, int newRating)
    {
        // check if player exists in dictionary
        if (PlayerDict.ContainsKey(name))
        {
            // player exists - change player rating
            PlayerDict[p.name].rating = newRating;
        }
        else
        {
            // player doesnt exist - add the player
            addNewPlayer(name);
        }
    }
    public class Player
    {
        public string name { get; }
        public int rating { get; set; }
        public Player(string Playername, int PlayerRating)
        {
            name = Playername;
            rating = PlayerRating;
        }
    }
