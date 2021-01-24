    private static void OnChanged(object source, FileSystemEventArgs e)
    {
       if(e.ChangeType == WatcherChangeTypes.Changed)
       {
           string lastLine = File.ReadLines(e.FullPath).Last();
       }
    }
