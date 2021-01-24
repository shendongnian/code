    public class FilesSearcher : IDisposable
    {
        private readonly BlockingCollection<string[]> filesInMemory;
        private readonly string searchFolder;
        private readonly string[] searchList;
    
        public FilesSearcher(string searchFolder, string[] searchList)
        {
            // reader thread stores lines here
            this.filesInMemory = new BlockingCollection<string[]>(
                // limit count of files stored in memory, so if processing threads not so fast, reader will take a break and wait
                boundedCapacity: 100);
    
            this.searchFolder = searchFolder;
            this.searchList = searchList;
        }
    
        public IEnumerable<string> SearchContentListInFiles()
        {
    
            // start read,
            // we not need many threads here, probably 1 thread by 1 storage device is the optimum
            var filesReaderTask = Task.Factory.StartNew(ReadFiles, TaskCreationOptions.LongRunning);
    
            // at least one proccessing thread, because reader thread is IO bound
            var taskCount = Math.Max(1, Environment.ProcessorCount - 1);
    
            // start search threads
            var tasks = Enumerable
                .Range(0, taskCount)
                .Select(x => Task<string[]>.Factory.StartNew(Search, TaskCreationOptions.LongRunning))
                .ToArray();
    
            // await for results
            Task.WaitAll(tasks);
    
            // combine results
            return tasks
                .SelectMany(t => t.Result)
                .ToArray();
        }
    
        private string[] Search()
        {
            // if you always get unique results use list
            //var results = new List<string>();
            var results = new HashSet<string>();
    
            foreach (var content in this.filesInMemory.GetConsumingEnumerable())
            {
                // one pass by a file
                var currentFileMatches = content
                    .Where(sourceLine =>
                    {
                        // to lower one time for a line, and we don't need to make lowerd copy of file
                        var lower = sourceLine.ToLower();
    
                        return this.searchList.Any(sourceLine.Contains);
                    });
                    
                // store current file matches
                foreach (var currentMatch in currentFileMatches)
                {
                    results.Add(currentMatch);
                }                
            }
    
            return results.ToArray();
        }
    
        private void ReadFiles()
        {
            var files = Directory.EnumerateFiles(this.searchFolder);
    
            try
            {
                foreach (var file in files)
                {
                    var fileContent = File.ReadLines(file);
    
                    // add file, or wait if filesInMemory are full
                    this.filesInMemory.Add(fileContent.ToArray());
                }
            }
            finally
            {
                this.filesInMemory.CompleteAdding();
            }
        }
    
        public void Dispose()
        {
            if (filesInMemory != null)
                filesInMemory.Dispose();
        }
    }
