    var splitter = new string[] { Environment.NewLine };
    foreach (var line in File.ReadAllText(path)
                             .Split(splitter, StringSplitOptions.RemoveEmptyEntries))
    {
        // process each line.
    }
