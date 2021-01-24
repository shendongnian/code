    public class Game
    {
		public string name { get; set; } // Read about auto-properties
		public int cclass { get; set; }
		public int diff { get; set; }
		
        // This is the constructor that assigns the values passed to this class
		public Game(string n, int c, int d)
		{
			name = n;
			cclass = c;
			diff = d;
		}
		
        // Example of gameStart that shows the chosen values
        public void gameStart()
        {
			Console.WriteLine("GAME STARTED:");
			Console.WriteLine(string.Format("Name: {0}, Class: {1}, Difficulty: {2}", name, cclass, diff));
 
        }
    }
