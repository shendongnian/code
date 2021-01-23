    public static class Program
    {
        const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random Random = new Random();
        private static string RandomString(int length)
        {
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
        private static void Main()
        {
            var random = new Random();
            var largeCollection =
                Enumerable.Range(0, 1000000)
                    .Select(
                        x =>
                            new EnumerableClass
                            {
                                A = RandomString(500),
                                B = RandomString(1000),
                                C = RandomString(100),
                                D = RandomString(256),
                                E = RandomString(1024),
                                F = Frame.GetFrame(),
                                Gatorade = Gatorade.GetGatoradeBottle(),
                                Home = Home.GetUnitOfHome(),
                                X = random.Next(1000),
                                Y = random.Next(1000)
                            })
                    .ToList();
            const int conditionValue = 250;
            Console.WriteLine(@"Condition value: {0}", conditionValue);
            var sw = new Stopwatch();
            sw.Start();
            var firstWhere = largeCollection
                .Where(x => x.Y < conditionValue)
                .Select(x => x.Y)
                .ToArray();
            sw.Stop();
            Console.WriteLine(@"Where -> Select: {0} ms", sw.ElapsedMilliseconds);
            sw.Restart();
            var firstSelect = largeCollection
                .Select(x => x.Y)
                .Where(y => y < conditionValue)
                .ToArray();
            sw.Stop();
            Console.WriteLine(@"Select -> Where: {0} ms", sw.ElapsedMilliseconds);
            Console.ReadLine();
            
            Console.WriteLine();
            Console.WriteLine(@"First Where's first item: {0}", firstWhere.FirstOrDefault());
            Console.WriteLine(@"First Select's first item: {0}", firstSelect.FirstOrDefault());
            Console.WriteLine();
            Console.ReadLine();
        }
    }
