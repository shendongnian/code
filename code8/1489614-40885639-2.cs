    static void Main(string[] args)
    {
        GuidStore gs = new GuidStore(Guid.NewGuid());
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine(i);
            ConcurrentDictionary<Guid, int> guids = new ConcurrentDictionary<Guid, int>();
            Parallel.For(0, 1000, j =>
            {
                Guid currentGuid = gs.GetNextGuid();
                if (!guids.TryAdd(currentGuid, j))
                {
                    Console.WriteLine("Duplicate found!");
                }
            }); // Parallel.For
        }
        Console.WriteLine("Press ENTER to Exit");
        Console.ReadLine();
    }
