    static void Main(string[] args)
    {
        var result = Map.FirstOrDefault(w => w.Item1 == 4 && w.Item2 == 4);
        if (result.Equals(default(ValueTuple<int, int, int>)))
            Console.WriteLine("Not found");
        else
            Console.WriteLine("Found");
    }
