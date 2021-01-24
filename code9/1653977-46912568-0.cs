    private static void CopyDirectory(string from, string to)
    {
        var toFileNames = new DirectoryInfo(to)
            .GetFiles()
            .Select(f => f.Name)
            .ToList();
        var directory = new DirectoryInfo(from);
        var files = directory.GetFiles();
        foreach (var file in files)
            if (!toFileNames.Contains(file.Name))
                file.CopyTo(Path.Combine(to, file.Name));
        var subDirectories = directory.GetDirectories();
        foreach (var subDirectory in subDirectories)
        {
            var newDirectory = Directory.CreateDirectory(Path.Combine(to, subDirectory.Name));
            CopyDirectory(subDirectory.FullName, newDirectory.FullName);
        }
    }
