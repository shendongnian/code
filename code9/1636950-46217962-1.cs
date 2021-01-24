    public void CreateFileWatcher(string path)
    {
        // Create a new FileSystemWatcher and set its properties.
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = path;
        /* Watch for LastWrite changes */
        watcher.NotifyFilter = NotifyFilters.LastWrite;
        // Only watch log files.
        watcher.Filter = "*.log";
    
        // Add event handlers.
        watcher.Changed += new FileSystemEventHandler(OnChanged);
    
        // Begin watching.
        watcher.EnableRaisingEvents = true;
    }
    
    // Define the event handlers.
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        // Read log and get diff here.
       Console.WriteLine("File has changed. Syncing log...");
    }
