    [assembly: PreApplicationStartMethod(typeof(Demo.CompilationWatcher), "Initialize")]
    namespace Demo
    {
        public static class CompilationWatcher
        {
            public static void Initialize()
                {
                    while (true)
                    {
        
                        FileSystemWatcher watcher = new FileSystemWatcher();
                        watcher.Path = AppDomain.CurrentDomain.DynamicDirectory;
                        watcher.IncludeSubdirectories = true;
        
                        watcher.NotifyFilter = NotifyFilters.Attributes |
                        NotifyFilters.CreationTime |
                        NotifyFilters.DirectoryName |
                        NotifyFilters.FileName |
                        NotifyFilters.LastAccess |
                        NotifyFilters.LastWrite |
                        NotifyFilters.Security |
                        NotifyFilters.Size;
        
                        watcher.Filter = "*.*"; // consider filtering only *.dll, *.compiled etc
        
                        watcher.Changed += new FileSystemEventHandler(OnChanged);
                        watcher.Created += new FileSystemEventHandler(OnChanged);
        
                        watcher.EnableRaisingEvents = true;
                    }
        
                }
        
                public static void OnChanged(object source, FileSystemEventArgs e)
                {
                    // your thread-safe logic here to log e.Name, e.FullPath, an d get the source file through reflection / name etc. ... 
                }
        
        }
    }
