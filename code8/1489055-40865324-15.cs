    public static IEnumerable<string> AllFolders(string root)
    {
        var folders = new List<string> {root};
        while (folders.Count > 0)
        {
            string folder = folders[folders.Count - 1];
            folders.RemoveAt(folders.Count-1);
            yield return folder;
            folders.AddRange(Directory.EnumerateDirectories(folder));
        }
    }
