     Public void WatchItBaby()
     {
        // ...
        FileSystemWatcher watcher = new FileSystemWatcher(@"c:\temp\", "*.txt");			
	    watcher.Created += new FileSystemEventHandler(OnChangedOrRenamed);			
	    watcher.Renamed += new RenamedEventHandler(OnChangedOrRenamed);
	    watcher.EnableRaisingEvents = true;
        // ...
     }
     private void OnChangedOrRenamed(object source, FileSystemEventArgs e)
	 {
		// stuff		
	 }
