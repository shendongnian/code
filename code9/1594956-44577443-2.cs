    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>
            {
                "121:sdfdsfds",
                "122:sdfdsfds",
                "123:sdfdsfds"
            };
            List<string> Results = strings
                .Select(s => s.Split(':')[0])
                .ToList();
            Results.ForEach(s => Console.WriteLine(s));
            Console.ReadKey();
        }
    }
