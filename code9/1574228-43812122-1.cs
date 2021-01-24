    public static void Main()
    {
        var x = Enumerable.Range(0, 10).Select(n => new Tuple<int, string>(n, $"Item {n + 1}"));
        
        Test(x);
    }
    private static void Test(IEnumerable<Tuple<int, string>> stuff)
    {
        foreach (var item in stuff)
        {
            Console.Write($"{item.Item1}: {item.Item2}");
        }
    }
