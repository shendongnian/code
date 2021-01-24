    class Program
        {
            private static string _directoryName = @"c:\items";
    
            private static readonly BlockingCollection<string> FilesList = new BlockingCollection<string>();
    
            static void Main(string[] args)
            {
                Run();
    
                var myfiles = Directory.GetFiles(_directoryName).ToList();
    
                foreach (var file in myfiles)
                {
                    FilesList.Add(file);
                }
    
                foreach (var item in FilesList.GetConsumingEnumerable())
                {
                    Console.WriteLine(item);
                }
    
                Console.ReadLine();
            }
    
            public static void Run()
            {
                var watcher = new FileSystemWatcher { Path = _directoryName };
                watcher.Created += (source, e) =>
                {
                    FilesList.Add(e.FullPath);
                };
                watcher.EnableRaisingEvents = true;
            }
        }
