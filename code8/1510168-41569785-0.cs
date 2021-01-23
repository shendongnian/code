    int intBorder = 1900;
            int intN = int.Parse(Console.ReadLine());
            List<int> listPoints = new List<int>();
            List<int> listRanks = new List<int>();
            for (int i = 0; i < intBorder; i++)
            {
                listPoints.Add(int.Parse(""+Console.ReadKey().KeyChar));
                listRanks.Add(int.Parse("" + Console.ReadKey().KeyChar));
                Console.ReadLine();
            }
