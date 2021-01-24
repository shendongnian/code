    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Raw data
                string rawData = "10,2/20,5/50,3";
    
                // First split
                string[] playersRaw = rawData.Split('/');
    
                // Initialize a collection for the player objects
                var players = new List<Player>();
    
                // Iterates over the splitted players data
                foreach (var playerRaw in playersRaw)
                {
                    // Deserialize each player 
                    var playerDeserialized = Player.Deserialize(playerRaw);
    
                    // Store the player data into the players collection
                    if (playerDeserialized != null)
                        players.Add(playerDeserialized);
                }
    
                // Seeks for player with room prize 10
                foreach (var player in players)
                {
                    if (player.RoomPrize == 10)
                        // Increments players data wins count
                        player.Wins += 1;
                }
    
                // Updates the raw data serializing all players back again
                rawData = string.Join("/", Array.ConvertAll(players.ToArray(), (p) => p.Serialize()));
    
                Console.WriteLine(rawData);
    
                Console.ReadLine();
            }
        }
    
        class Player
        {
            public int RoomPrize { get; set; }
    
            public int Wins { get; set; }
    
            public static Player Deserialize(string data, char separator = ',')
            {
                Player player = null;
                string[] splittedData = new string[] { };
    
                if (!string.IsNullOrEmpty(data) && (splittedData = data.Split(separator)).Length == 2)
                {
                    int roomPrize = 0, wins = 0;
                    if (int.TryParse(splittedData[0], out roomPrize) && int.TryParse(splittedData[1], out wins))
                    {
                        player = new Player();
                        player.RoomPrize = roomPrize;
                        player.Wins = wins;
                    }
                }
    
                return player;
            }
    
            public string Serialize()
            {
                return string.Format("{0},{1}", this.RoomPrize, this.Wins);
            }
        }
    }
