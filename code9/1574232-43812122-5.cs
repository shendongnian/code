    public static Main()
    {
        var x = Enumerable.Range(0, 10).Select(n => new { ID = n, Value = $"Item {n + 1}" });
            
        Test(x);
    }
    private static void Test(dynamic message)
    {
        foreach (dynamic item in message)
        {
            Console.Write($"{item.ID}: {item.Value}");
        }
    }
