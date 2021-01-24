    public class SomeService
    {
	    private FileSystemWatcher _watcher;
        public void OnStart()
        {
            // set up the watcher
            _watcher = new FileSystemWatcher(_location);
            _watcher.Path = path;
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.Filter = "*.*";
            _watcher.Changed += new FileSystemEventHandler(OnChanged);
            _watcher.EnableRaisingEvents = true;
        }
    }
