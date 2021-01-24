    static string CorrectClassNameCasing(string input)
    {
        var filePath = @"f:\public\temp\classnames.txt";
        var knownClassNames = File.ReadAllLines(filePath);
        return knownClassNames
            .FirstOrDefault(name => name.Equals(input, StringComparison.OrdinalIgnoreCase)) ?? input;
    }
