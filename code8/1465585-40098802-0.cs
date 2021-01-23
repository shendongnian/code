    class FileWorker
    {
        private ConcurrentDictionary<string, Task> _destTasks;
        public FileWorker()
        {
            _destTasks = new ConcurrentDictionary<string, Task>();
        }
        
        public async Task Copy(IEnumerable<FileInfo> files, string destinationFolder)
        {
            await Task.WhenAll(files.Select(f => Copy(f, destinationFolder)));
        }
        private async Task CreateDestination(string path)
        {
            await Task.Run(() =>
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            });
        }
        private Task Destination(string path)
        {
            if(!_destTasks.ContainsKey(path))
            {
                _destTasks[path] = CreateDestination(path);
            }
            return _destTasks[path];
        }
        private async Task Copy(FileInfo file, string destinationFolder)
        {
            await Destination(destinationFolder).ContinueWith(task => file.CopyTo(Path.Combine(destinationFolder, file.Name)));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var file1 = new FileInfo("file1.tmp");
            using(var writer = file1.CreateText())
            {
                writer.WriteLine("file 1");
            }
            var file2 = new FileInfo("file2.tmp");
            using(var writer = file2.CreateText())
            {
                writer.WriteLine("file 2");
            }
            var worker = new FileWorker();
            worker.Copy(new[] { file1, file2 }, @"C:\temp").Wait();
            Console.ReadLine();
        }
    }
