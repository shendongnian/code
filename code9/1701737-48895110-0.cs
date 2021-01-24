    public static void FileWatcher(string fileName, int timeToWatch)
    {
    	FileSystemWatcher watcher = new FileSystemWatcher();
    	var timeout = Task.Delay(timeToWatch);
    	var completedTcs = new TaskCompletionSource<bool>();
    
    	watcher.Path = myPath;
    	watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
    	watcher.Filter = string.Format("*{0}*", fileName);
    	watcher.Deleted += (s, e) => OnChanged(myPath, timeout, completedTcs);
    	watcher.EnableRaisingEvents = true;
    
        OnChanged(myPath, timeout, completedTcs);
    	var completed = Task.WaitAny(completedTcs.Task, timeout);
    
    	if (completed == 1)
    	{
    		// Timed out			
    		throw new Exception("Files not deleted in time");
    	}
    }
    
    public static void OnChanged(string path, Task timeout, TaskCompletionSource<bool> completedTcs)
    {
    	if (!Directory.GetFiles(path).Any())
    	{
    		// All files deleted (not recursive)
    		completedTcs.SetResult(true);
    	}
    }
