        static void Main(string[] args)
        {
            Tuple<int, int>[] pairs = new Tuple<int, int>[]
                {
                    Tuple.Create(5, 2),
                    Tuple.Create(6, 1),
                };
            System.Console.WriteLine(IsMatch(1, 3, pairs));
            System.Console.WriteLine(IsMatch(5, 2, pairs));
            System.Console.ReadKey();
        }
        static bool IsMatch(int x, int y, Tuple<int, int>[] pairs)
        {
            var results = 
                from pair in pairs
                where pair.Item1 == x && pair.Item2 == y
                select pair;
            return results.Any();
        }
