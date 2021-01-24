    static void Main(string[] args)
    {
        // Start with a dictionary of Ids and a List<string> of Infos
        var myData = new Dictionary<int, List<string>>
        {
            {1, new List<string> {"line 1", "line 2", "line 3" } },
            {2, new List<string> {"something else", "another thing" } },
        };
        // Convert it into a list of MyClass objects
        var itemList = myData.Keys
            .SelectMany(key => myData[key], (key, s) => new MyClass { Id = key, Info = s })
            .ToList();
        // Output each MyClass object to the Console window
        foreach(var item in itemList)
        {
            Console.WriteLine($"{item.Id}, {item.Info}");
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
