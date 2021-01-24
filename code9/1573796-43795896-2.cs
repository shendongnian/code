        class Program
        {
            static void Main(string[] args)
            {
                string xml =
     @"<Baseball>
        <Player playerID=""123"" playerName=""John Smith"" playerBats=""Right"">    
        <position positionID=""1b"" positionCode=""abc"" counter=""3""/>
        <position positionID=""2b"" positionCode=""def"" counter=""2""/>
        </Player>
    </Baseball>";
    
                var document = new XmlDocument();
                document.LoadXml(xml);
    
                var players = new List<Player>();
    
                foreach (XmlElement baseballElement in document.SelectNodes("Baseball"))
                {
                    foreach (XmlElement playerElement in baseballElement.SelectNodes("Player"))
                    {
                        players.Add(Player.FromXml(playerElement));
                    }
                }
                Console.ReadLine();
            }
        }
    
        public class Player
        {
            public static Player FromXml(XmlElement PlayerElement)
            {
                var player = new Player();
                player.PlayerId = int.Parse(PlayerElement.GetAttribute("playerID"));
                player.PlayerName = PlayerElement.GetAttribute("playerName");
                player.PlayerBats = PlayerElement.GetAttribute("playerBats");
    
                foreach (XmlElement positionElement in PlayerElement.SelectNodes("position"))
                {
                    player.Positions.Add(Position.FromXml(positionElement));
                }
                return player;
            }
    
            public int PlayerId { get; set; }
    
            public string PlayerName { get; set; }
    
            public string PlayerBats { get; set; }
    
            public List<Position> Positions { get; } = new List<Position>();
        }
        public class Position
        {
            public static Position FromXml(XmlElement positionElement)
            {
                var position = new Position();
                position.PositionId = positionElement.GetAttribute("positionID");
                position.PositionCode = positionElement.GetAttribute("positionCode");
                position.Counter = int.Parse(positionElement.GetAttribute("counter"));
    
                return position;
            }
    
            public string PositionId { get; set; }
            public string PositionCode { get; set; }
            public int Counter { get; set; }
        }
