    var path = @"c:\public\temp";
    DirectoryInfo dir = new DirectoryInfo(path);
    foreach (var file in dir.GetFiles("*.txt"))
    {
        foreach (var line in File.ReadAllLines(file.FullName))
        {
            if (line.StartsWith("0001") || line.StartsWith("0002"))
            {
                var lineParts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                // This is assuming that the word count
                // is in the column (which has index 2)
                if (lineParts.Length > 2)
                {
                    var wordCount = lineParts[2];
                            Console.WriteLine($"Found data in file {file.Name}:");
                            Console.WriteLine($" - Line starts with {lineParts[0].Substring(0, 4)}");
                            Console.WriteLine($" - Has word count of {wordCount}");
                }
            }
        }
    }
