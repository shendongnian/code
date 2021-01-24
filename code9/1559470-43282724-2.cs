    var allEntries = new Dictionary<int, List<Entry>>{
        [5]=new List<Entry>{
                            new Entry{SomeProperty="sdf"},
                            new Entry{SomeProperty="sdasdf"}
                            },
        [11]=new List<Entry>{
                            new Entry{SomeProperty="sdfasd"},
                            new Entry{SomeProperty="sdasdfasdf"}
                            },    };
    foreach(var (key, entries) in allEntries)
    {
        Console.WriteLine(key);
        foreach(var entry in entries)
        {
            Console.WriteLine($"\t{entry.SomeProperty}");
        }
    }
