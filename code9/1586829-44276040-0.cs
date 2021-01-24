    FileSystemWatcher watcher = new FileSystemWatcher(@"D:\Outgoing", "*.txt");
    watcher.Changed += new FileSystemEventHandler(OnChanged);
    //watcher.Created += new FileSystemEventHandler(OnCreated); // not interested
    watcher.Deleted += new FileSystemEventHandler(OnChanged);
    watcher.Renamed += new RenamedEventHandler(OnRenamed);
    watcher.EnableRaisingEvents = true;
    ...
