    private static void Main()
    {
        var scanDirectory = @"f:\public\temp\";
        var processedDirectory = @"f:\public\temp2\";
        // The lists that define a complete group
        var fileGroupDefinitions = new List<List<string>>
        {
            new List<string> {"FG1A", "FG1B", "FG1C"},
            new List<string> {"FG2A", "FG2B", "FG2C", "FG2D"}
        };
        // Populate a list of FileGroupItems from the files 
        // in our directory, and group them on the DatePart
        var fileGroups = Directory.EnumerateFiles(scanDirectory)
            .Select(FileGroupItem.Parse)
            .GroupBy(f => f.DatePart);
        // Now go through each group and compare the items 
        // for that date with our file group definitions
        foreach (var fileGroup in fileGroups)
        {
            foreach (var fileGroupDefinition in fileGroupDefinitions)
            {
                // Get the intersection of the group definition and this file group
                var intersection = fileGroup
                    .Where(f => fileGroupDefinition.Contains(
                        f.GroupName, StringComparer.OrdinalIgnoreCase))
                    .ToList();
                // If all the items in the definition are there, then process the files
                if (intersection.Count == fileGroupDefinition.Count)
                {
                    foreach (var fileGroupItem in intersection)
                    {
                        Console.WriteLine($"Processing file: {fileGroupItem.FilePath}");
                        // Move the file to the processed directory
                        File.Move(fileGroupItem.FilePath,
                            Path.Combine(processedDirectory,
                                Path.GetFileName(fileGroupItem.FilePath)));
                    }
                }
            }
        }
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
