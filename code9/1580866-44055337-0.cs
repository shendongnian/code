    namespace bs
    {
    struct CollectionEvent
    {
        public DateTime Retrieved { get; set; }      
        public String IP { get; set; }  
    }
    static class Accumulator
    {
        private static List<int> Items { get; set; } = new List<int>();
        private static bool Mutex { get; set; } = false;
        private static List<CollectionEvent> Collections { get; set; } = new List<CollectionEvent>();
        public static void Add(int i)
        {
            Sync(() => Items.Add(i));
        }
        public static List<int> Retrieve(String IP)
        {
            Collections.Add(new CollectionEvent
            {
                Retrieved = DateTime.UtcNow,
                IP = IP
            });
            List<int> dataOut = null;
            Sync(() =>
            {
                dataOut = new List<int>(Items);
                Items = new List<int>();
            });
            return dataOut;
        }
        public static void Sync(Action fn)
        {
            const int Threshold = 10;
            int attempts = 0;
            for (; Mutex && (attempts < Threshold); attempts++)
                Thread.Sleep(100 * attempts);
            if (attempts == Threshold)
                throw new Exception(); // or something better I'm sure
            Mutex = true;
            fn();
            Mutex = false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            var m = r.Next(5, 10);
            for (int i = 0; i < m; i++)
            {
                var datum = r.Next(100, 10000);
                Console.WriteLine($"COLLECT {datum}");
                Accumulator.Add(datum);
            }
            Console.WriteLine("RETRIEVE");
            Accumulator.Retrieve("0.0.0.0").ForEach(i => Console.WriteLine($"\t{i}"));
            m = r.Next(5, 10);
            for (int i = 0; i < m; i++)
            {
                var datum = r.Next(100, 10000); 
                Console.WriteLine($"COLLECT {datum}");
                Accumulator.Add(datum);
            }
            Console.WriteLine("RETRIEVE");
            Accumulator.Retrieve("0.0.0.0").ForEach(i => Console.WriteLine($"\t{i}"));
            Console.Read();
        }
    }
    }
