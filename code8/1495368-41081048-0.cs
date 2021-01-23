    static void Main(string[] args)
    {
        var files = Directory.EnumerateFileSystemEntries(@"E:\Users\Myleo\Pictures", "*.*", SearchOption.AllDirectories);
        var program = new Program();
        var result = program.ProcessInParallelWithCounter(files);
        Console.WriteLine("count: {0}", result);
        #if DEBUG
            Console.ReadKey();
        #endif
    }
    private void ProcessInParallel(IEnumerable<string> files)
    {
        // process
        Parallel.ForEach(files, Process);
    }
    private int ProcessInParallelWithCounter(IEnumerable<string> files)
    {
        // process and count
        var counter = 0;
        Parallel.ForEach(
            files,
            () => 0,
            (file, loopState, localCount) =>
                                            {
                                                Process(file);
                                                return ++localCount;
                                            },
            count => Interlocked.Add(ref counter, count));
        return counter;
    }
    private void Process(string file)
    {
        // your code.
    }
