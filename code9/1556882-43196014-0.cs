    static void Main(string[] args)
        {
            Watcher w = new Watcher();
            w.watch(@"someLocation", (source, e) => { MoveFiles.Move(); });
        }
        public void watch(string pathName, FileSystemEventHandler OnChanged)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = pathName;
            watcher.Filter = "*.*";
            watcher.Created += OnChanged;
            watcher.EnableRaisingEvents = true;
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
