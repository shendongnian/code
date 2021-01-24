    static void Main(string[] args)
    {
        var watcher = new FileSystemWatcher();
        watcher.Path = @"C:\test_dir";
        // watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName;
        watcher.Filter = "*.*";
        watcher.Changed += new FileSystemEventHandler(OnChanged);
        watcher.Created += new FileSystemEventHandler(OnChanged);
        watcher.Deleted += new FileSystemEventHandler(OnChanged);
        watcher.Renamed += new RenamedEventHandler(OnRenamed);
        watcher.IncludeSubdirectories = true;
        watcher.EnableRaisingEvents = true;
        while (true)
        {
        }
    }
    private static void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"OnRenamed: {e.FullPath}, {e.OldFullPath}");
    }
    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"OnChanged: {e.ChangeType}, {e.Name}[{e.FullPath}]");
    }
