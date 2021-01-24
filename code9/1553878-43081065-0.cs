    class Program
    {
        static void Main(string[] args)
        {
            var source = "D:\\temp\\folder";
            // Create the new watcher and hook up events
            var fsw = new FileSystemWatcher(source)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Attributes | NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.Security,
                IncludeSubdirectories = true,
                InternalBufferSize = 64000
            };
            using (fsw)
            {
                fsw.Renamed += (o, e) => Console.WriteLine($"{e.OldFullPath} renamed to {e.FullPath}");
                fsw.Error += (o, e) => Console.WriteLine($"{e}");
                fsw.Deleted += (o, e) => Console.WriteLine($"{e.FullPath} deleted");
                fsw.Changed += (o, e) => Console.WriteLine($"{e.FullPath} changed");
                fsw.Created += (o, e) => Console.WriteLine($"{e.FullPath} created");
                fsw.EnableRaisingEvents = true;
                Console.WriteLine("Ready. Press 'Q' to exit");
                while (Console.ReadKey().KeyChar != 'Q')
                {
                }
            }
        }
    }
    
