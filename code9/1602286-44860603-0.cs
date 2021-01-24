    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                new Player(FILENAME);
            }
        }
        public class Player
        {
            const int NAME_COL_WIDTH = 20;
            public static List<Player> players = new List<Player>();
            public string name { get; set; }
            public int score { get; set; }
            public Player() { } //player constructor with no parameters
            public Player(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                while((inputLine = reader.ReadLine()) != null)
                {
                    Player newPlayer = new Player();
                    players.Add(newPlayer);
                    newPlayer.name = inputLine.Substring(0, NAME_COL_WIDTH).Trim();
                    newPlayer.score = int.Parse(inputLine.Substring(NAME_COL_WIDTH));
                }
                reader.Close();
            }
        }
    }
