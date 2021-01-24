    foreach(var item in classArray[1])
    {
        Console.WriteLine($"Id {item.Id} has names:");
        for (int i = 0; i < item.Names.Count; i++)
        {
            Console.WriteLine($" - {item.Names[i]}");
        }
    }
