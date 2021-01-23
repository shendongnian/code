    static void Main(string[] args)
    {
       FileSystemWatcher watcher = new FileSystemWatcher();
       string filePath = @"d:\watchDir";
       watcher.Path = filePath;
       watcher.EnableRaisingEvents = true;
       watcher.NotifyFilter = NotifyFilters.FileName;
       watcher.Filter = "*.*";
       // will track changes in sub-folders as well
       watcher.IncludeSubdirectories = true;
       watcher.Created += new FileSystemEventHandler(OnChanged);
       new System.Threading.AutoResetEvent(false).WaitOne();
    }
