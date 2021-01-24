    public void ListOpticalDiscDrivesAndWatchRootDirectory()
    {
        var drives = DriveInfo.GetDrives();
    
        foreach (var drive in drives)
        {
            if (drive.IsReady && drive.DriveType == DriveType.CDRom)
            {
                var rootDirectory = drive.RootDirectory.ToString();
                Console.WriteLine(rootDirectory);
                Watch(rootDirectory);
            }
        }
    }
    
    private void Watch(string path)
    {
        var watcher = new FileSystemWatcher
        {
            Path = path,
            NotifyFilter = NotifyFilters.Attributes |
            NotifyFilters.CreationTime |
            NotifyFilters.DirectoryName |
            NotifyFilters.FileName |
            NotifyFilters.LastAccess |
            NotifyFilters.LastWrite |
            NotifyFilters.Security |
            NotifyFilters.Size,
            Filter = "*.*",
            EnableRaisingEvents = true
        };
    
        watcher.Changed += new FileSystemEventHandler(OnChanged);
    }
    
    private void OnChanged(object source, FileSystemEventArgs e)
    {
        Console.WriteLine("Something changed!");
    }
