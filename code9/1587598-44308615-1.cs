    class Program
    {
        private static readonly List<(int a, int b, int c)> Map = 
            new List<(int a, int b, int c)>()
        {
            (1, 1, 2),
            (1, 2, 3),
            (2, 2, 4),
            (0, 0, 0)
        };
        static void Main(string[] args)
        {
            var result = Map.TryFirst(w => w.a == 0 && w.b == 0);
            Console.WriteLine(result.HasValue ? "Found" : "Not found");
        }
    }
