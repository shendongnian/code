    FileSystemWatcher watcher;
    
    private void Watch()
    {
      watcher = new FileSystemWatcher();
      watcher.Path = path;
      watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                             | NotifyFilters.FileName | NotifyFilters.DirectoryName;
      watcher.Filter = "*.*";
      watcher.Changed += new FileSystemEventHandler(OnChanged);
      watcher.EnableRaisingEvents = true;
    }
    
    private void OnChanged(object source, FileSystemEventArgs e)
    {
       CopyFile(e.FullPath);
    }
    private void CopyFile(string fileNameAndPath)
    {
       // copy file
       // make sure file exists at new  location
       // perform database operation
    }
