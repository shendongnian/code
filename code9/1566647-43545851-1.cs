    static void Main(string[] args)
    {
        var doubles = new List<double>();
        var rnd = new Random();
        for (var i = 0; i < 100000; i++)
        {
            var nbr = rnd.NextDouble();
            if (!doubles.Contains(nbr))
                doubles.Add(nbr);
            else
            {
                Console.WriteLine($"Match");
            }
        }
        Console.WriteLine("Finished");
    }
