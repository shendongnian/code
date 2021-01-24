    static void Main(string[] args)
    {
        int numberOfThreads = int.Parse(args[0]);
        Task.WaitAll(
            Enum.Range(0, numberOfThreads)
                .Select(
                    Task.Factory.StartNew(() => doStuff())
                )
                .ToArray()
            )
        );
        Console.WriteLine("Done !");
    }
