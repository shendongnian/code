        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            string filePath = @"d:\watchDir";
            watcher.Path = filePath;
            watcher.EnableRaisingEvents = true;
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;
            watcher.Created += new FileSystemEventHandler(OnFileCreated);
            new System.Threading.AutoResetEvent(false).WaitOne();
        }
        private static void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            if(e.ChangeType == WatcherChangeTypes.Created)
               // some code            
        }
