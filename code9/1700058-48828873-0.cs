    public static void Main()
    {
        var listme = new List<string> {"A", "A", "B", "C", "C"};
    
        // count
        var countDict = listme.GroupBy(i => i)
            .ToDictionary(i => i.Key, i => i.Count());
    
        foreach (var kv in countDict)
        {
            Console.WriteLine($"{kv.Key}: {kv.Value}");
        }
    
        // remove
        listme.RemoveAll(s => s == "A");
        foreach (string s in listme)
        {
            Console.WriteLine(s);
        }
    
        Console.ReadLine();
    }
