        static void Main(string[] args)
        {
            //*****init for test
            List<Game> g = new List<Game>();
            Game g1 = new Game();
            g1.level = 1;
            g1.xp = 0;
            g.Add(g1);
            g1.level = 2;
            g1.xp = 83;
            g.Add(g1);
            g1.level = 3;
            g1.xp = 174;
            g.Add(g1);
            g1.level = 7;
            g1.xp = 276;
            g.Add(g1);
            //**********
            //setting your xp in order to find your level
            g1.level = -1;//because you do not know
            g1.xp = 200;
            g.Add(g1);
            List<Game> new_list = g.OrderBy(x => x.xp).ToList();
            for (int i = 0; i < new_list.Count; i++)
            {
                if (new_list[i].xp == 200)
                {
                    Console.WriteLine("Your level is: " + new_list[i-1].level);
                }
            }
        }
    }
    struct Game
    {
        public int level { get; set; }
        public int xp { get; set; }
    }
