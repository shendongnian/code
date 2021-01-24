        public class data
        {
            public ArrayOfMatches ArrayOfMatches { get; set; }
        }
    
        public class ArrayOfMatches
        {
            public DateTime Date { get; set; }
            public Match Match { get; set; }
        }
        public class Match
        {
            public String TimeSlot { get; set; }
            public int Game_Id { get; set; }
            public Team[] ArrayOfTeams { get; set; }
        }    
    
        public class Team { 
            public int Team_id { get; set; }
            public string Team_Name { get; set; }
            public Player[] TeamPlayers { get; set; }
        }   
    
        public class Player
        {
            public int PlayerId { get; set; }
            public string PlayerName { get; set; }
            public string PlayerSurname { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                using (FileStream fileStream = new FileStream(@"C:\temp\input.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(data));
                    data result = (data)serializer.Deserialize(fileStream);
                }
    
            }
        }
