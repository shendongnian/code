    public static void Main()
    {
        Iterate(new Dictionary<string, object> { ["1"] = "one", ["2"] = "Two" });
        Console.Read();
    }
    public static void Iterate(Dictionary<string, object> args)
    {
        foreach (var item in args)
        {
            Console.WriteLine("key: " + item.Key + " value: " + item.Value);
        }
    }
