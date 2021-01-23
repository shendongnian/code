    public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
    {
        string[] searchPatterns = searchPattern.Split('|');
        List<string> files = new List<string>();
        foreach (string sp in searchPatterns)
            files.AddRange(System.IO.Directory.GetFiles(path, sp, searchOption));
        files.Sort();
        return files.ToArray();
    }
