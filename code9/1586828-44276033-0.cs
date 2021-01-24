    FileSystemWatcher watcher = new FileSystemWatcher(@"D:\Sujith\Test folder");
    watcher.Changed += new FileSystemEventHandler(watcher_changed);
    watcher.Renamed += new RenamedEventHandler(watcher_renamed);
    watcher.Deleted += new FileSystemEventHandler(watcher_deleted);
    watcher.EnableRaisingEvents = true;
