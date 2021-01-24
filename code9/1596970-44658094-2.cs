    class Program
    {
        static void Main(string[] args)
        {
            Start:
            
            List<Test> TestList = new List<Test>();
            int ObjectsToCreate = 1000000;
            Console.WriteLine($"Creating {ObjectsToCreate} Objects!");
            for (int x = 1; x <= ObjectsToCreate; x++)
            {
                TestList.Add(new Test() { Name = RandomString(100) });
            }
            Console.WriteLine($"Created {TestList.Count} objects.");
            string StringToSearchFor = "A";
            Console.WriteLine($"Benchmarking Now");
            System.Diagnostics.Stopwatch Watch = System.Diagnostics.Stopwatch.StartNew();
            var TestCollection = TestList.Where(Item => Item.Name.Contains(StringToSearchFor));
            Watch.Stop();
            Console.WriteLine($"Elapsed Time With Where Into VAR: {Watch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Elapsed Time With Where Into VAR: {Watch.ElapsedTicks} ticks");
            Watch = System.Diagnostics.Stopwatch.StartNew();
            IEnumerable<Test> TestCollection_ = TestList.Where(Item => Item.Name.Contains(StringToSearchFor));
            Watch.Stop();
            Console.WriteLine($"Elapsed Time With Where Into IEnumerable<Test>: {Watch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Elapsed Time With Where Into IEnumerable<Test>: {Watch.ElapsedTicks} ticks");
            Watch = System.Diagnostics.Stopwatch.StartNew();
            List<Test> TestCollection2 = TestList.Where(Item => Item.Name.Contains(StringToSearchFor)).ToList();
            Watch.Stop();
            Console.WriteLine($"Elapsed Time With Where Into List<Test>: {Watch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Elapsed Time With Where Into List<Test>: {Watch.ElapsedTicks} ticks");
            Watch = System.Diagnostics.Stopwatch.StartNew();
            List<Test> TestCollection3 = TestList.AsParallel().Where(Item => Item.Name.Contains(StringToSearchFor)).ToList();
            Watch.Stop();
            Console.WriteLine($"Elapsed Time With AsParallel First Where Into List<Test>: {Watch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Elapsed Time With AsParallel First Where Into List<Test>: {Watch.ElapsedTicks} ticks");
            Watch = System.Diagnostics.Stopwatch.StartNew();
            List<Test> TestCollection4 = TestList.Where(Item => Item.Name.Contains(StringToSearchFor)).AsParallel().ToList();
            Watch.Stop();
            Console.WriteLine($"Elapsed Time With AsParallel Last Where Into List<Test>: {Watch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Elapsed Time With AsParallel Last Where Into List<Test>: {Watch.ElapsedTicks} ticks");
            Console.ReadLine();
            goto Start;
        }
        public class Test
        {
            public string Name { get; set; }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
