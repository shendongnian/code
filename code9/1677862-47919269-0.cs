    private void watch()
    {
      FileSystemWatcher watcher = new FileSystemWatcher();
      
      // Set your path with this
      watcher.Path = path;
      
      // Subscribe to event
      watcher.Changed += new FileSystemEventHandler(OnChanged);
      watcher.EnableRaisingEvents = true;
    }
