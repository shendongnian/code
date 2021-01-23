        static void Main()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            string filePath = ConfigurationManager.AppSettings["documentPath"];
            watcher.Path = filePath;
            watcher.EnableRaisingEvents = true;
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.Filter = "*.*";
            watcher.Created += new FileSystemEventHandler(OnChanged);
            // wait - not to end
            new System.Threading.AutoResetEvent(false).WaitOne();
        }
