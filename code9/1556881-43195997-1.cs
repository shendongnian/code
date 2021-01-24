    public void watch(string pathName, FileSystemEventHandler OnChanged)
    {
       // ...
       watcher.Created += OnChanged;
    }
