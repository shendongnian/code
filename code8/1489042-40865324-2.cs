    public static IEnumerable<string> AllFolders(string root)
    {
        var folders = new Stack<string>();
        folders.Push(root);
        while (folders.Count > 0)
        {
            string folder = folders.Pop();
            yield return folder;
            foreach (var item in Directory.EnumerateDirectories(folder))
                folders.Push(item);
        }
    }
