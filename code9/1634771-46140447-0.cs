    public static bool HasExecutable(string path)
        {
            var exts = "*.exe";
            return Directory.EnumerateFiles(path, exts).Any();
        }
