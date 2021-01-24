    // Display new dictionary results
    Console.WriteLine("\nDictionary Contents After Processing Commits");
    Console.WriteLine("--------------------------------------------");
    foreach (var dictionaryItem in sorted)
    {
        Console.WriteLine("Key: {0} Value: {1}", dictionaryItem.Key.ToString().PadRight(27), 
            dictionaryItem.Value);
    }
    Console.WriteLine($"\nSum of all values is: {sorted.Values.Sum()}\n");
