    static void Main(string[] args)
    {
        foreach(var pair in GetPairs(1, 8, new Random()))
        {
            Console.WriteLine($"One: {pair.Item1} Two: {pair.Item2}");
        }
    }
