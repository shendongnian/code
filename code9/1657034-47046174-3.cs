    // Display new dictionary results
    Console.WriteLine("\nDictionary Contents After Processing Commits");
    Console.WriteLine("--------------------------------------------");
    foreach (var dictionaryItem in sorted)
    {
        Console.WriteLine($"Key: {dictionaryItem.Key}  Value: {dictionaryItem.Value}");
    }
