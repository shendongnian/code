        static void Main(string[] args)
        {
            int[][] arrayOfPairs = new int[][]
                {
                    new int[] { 5, 2 },
                    new int[] { 6, 1 },
                };
            System.Console.WriteLine(IsMatch(1, 3, arrayOfPairs));
            System.Console.WriteLine(IsMatch(5, 2, arrayOfPairs));
            System.Console.ReadKey();
        }
        static bool IsMatch(int x, int y, int[][] pairs)
        {
            var results = 
                from pair in pairs
                where pair[0] == x && pair[1] == y
                select pair;
            return results.Any();
        }
