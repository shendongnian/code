    void GetChildDirectories(string path, string pattern, Dictionary<string, int> stats)
    {
        try
        {
            var children = Directory.GetDirectories(path);
            var count = Directory.GetFiles(path, pattern).Length;
            stats[path] = count;
            foreach (var child in children)
                GetChildDirectories(child, pattern, stats);
        }
        catch (UnauthorizedAccessException e)
        {
            stats[path] = -1;
            return;
        }
    }
