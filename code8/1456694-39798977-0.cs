    static void Main(string[] args)
    {
        var results = File.ReadLines(filename)
                      .Select(n => string.Join(",", Enumerable.Range(2, int.Parse(n) - 2)
                                                              .Where(PrimeCheck)));
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
