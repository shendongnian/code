    static void Main(string[] args)
    {
        int numberOfThreads = int.Parse(args[0]);
        
        Parallel.For(
            1, 
            100, 
            new ParallelOptions
            {
                MaxDegreeOfParallelism = numberOfThreads
            },
            (i) => doStuff()
        );
        Console.WriteLine("Done !");
    }
