        var fw = new FileSystemWatcher();
        fw.EnableRaisingEvents = true;
        fw.Created += OnCreated;
    }
    
    private static void OnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
    {
        var name = fileSystemEventArgs.Name;
    }
