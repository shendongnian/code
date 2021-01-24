    public static async Task<IEnumerable<string>> ProcessAllFiles(string root, Func<iFile, string> fileToLineConverter, bool ignoreUnauthorizedAccess = true)
    {
        Stack<string> stack = new Stack<string>();
        List<Task<IEnumerable<string>>> resultTasks = new List<Task<IEnumerable<string>>>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            string curDir = stack.Pop();
            
            resultTasks.Add(Task.Run(() => ProcessFilesInDirectory(curDir, fileToLineConverter, ignoreUnauthorizedAccess)));
            string[] dirs = null;
            try
            {
                dirs = Directory.GetDirectories(curDir);
            }
            catch (UnauthorizedAccessException)
            {
                if (!ignoreUnauthorizedAccess) throw;
            }
            catch (IOException)
            {
                if (!ignoreUnauthorizedAccess) throw;
            }
            if (dirs != null)
                foreach (string dir in dirs)
                    stack.Push(dir);
        }
        var results = await Task.WhenAll(resultTasks);
        return results.SelectMany(x => x);
    }
    private static IEnumerable<string> ProcessFilesInDirectory(string curDir, Func<iFile, string> fileToLineConverter, bool ignoreUnauthorizedAccess)
    {
        FileInfo[] files = null;
        try
        {
            var dir = new DirectoryInfo(curDir);
            files = dir.GetFiles();
        }
        catch (UnauthorizedAccessException)
        {
            if (!ignoreUnauthorizedAccess) throw;
        }
        if (files != null)
            return files.Select(x => fileToLineConverter(new iFile(x))).ToList();
        return Enumerable.Empty<string>();
    }
    async Task ExecuteFull(string path)
    {
        var lines = await ProcessAllFiles(
            @"C:\",
            x => x.getPath() + ";" + x.getHash(),
            false);
        using (System.IO.StreamWriter f = new System.IO.StreamWriter(path))
        {
            foreach (var i in lines)
            {
                f.WriteLine(lines);
            }
        }
    }
