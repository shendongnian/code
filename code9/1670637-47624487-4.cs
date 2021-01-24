    public class Player
    {
        public int OneHanded { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        //  ...etc. etc. -- include EVERYTHING that is a property of a player. 
        //  Now your Stats() method has direct access to all the player's properties
        //  Print stats for THIS player
        public void PrintStats()
        {
            Console.Clear();
            Console.WriteLine("| |================================| |");
            Console.WriteLine("| | Character description + stats: | |");
            Console.WriteLine("| | Gender: {0}                    | |", Gender);
            Console.WriteLine("| | Race: {0}                    | |", Race);
        }
    }
