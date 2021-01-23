    public class Goalkeeper
    {
        public Goalkeeper() {
            Position = "Goalkeeper";
            Matches = 5;
            Cleansheets = 0;
        }
             
        public static string Name { get; set; }
        public static string Position { get; set; }
        public static int Matches { get; set; }
        public static int Cleansheets { get; set; }
    }
