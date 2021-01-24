    public void FileWatcherLoad()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = //some path;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }
