    private static void Main()
    {
        var filePath = @"f:\public\temp\temp.txt";
        // Read all file contents and split it on the word "Point:"
        var fileContents = Regex
            .Split(File.ReadAllText(filePath), "Point:", RegexOptions.IgnoreCase)
            .Where(point => !string.IsNullOrWhiteSpace(point))
            .Select(point => point.Trim());
        // Get all animals that are cats from the results
        var catList = fileContents
            .Select(Animal.Parse)
            .Where(animal => animal.Type == 5)
            .ToList();
        // Output results
        catList.ForEach(Console.WriteLine);
        // Wait for input before closing
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
