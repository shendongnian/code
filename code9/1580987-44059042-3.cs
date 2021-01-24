    foreach (var item in sliceSteppingList)
    {
        Console.WriteLine($"-{item.Key}");
        foreach (var subDir in item)
        {
            Console.WriteLine($" +{subDir}");
        }
    }
