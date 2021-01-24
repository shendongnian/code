    var highPriOptions = new DataflowLinkOptions(){MaxDegreeOfParallelism = 3}
    var highPriority = new ActionBlock<Token>(dt =>
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(250));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{DateTime.Now:mm:ss.fff}:{dt}");
    }, highPriOptions);
    var midPriOptions = new DataflowLinkOptions(){MaxDegreeOfParallelism = 2}   
    var midPriority = new ActionBlock<Token>(dt =>
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(250));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{DateTime.Now:mm:ss.fff}:{dt}");
    }, midPriOptions);
    
    var lowPriority = new ActionBlock<Token>(dt =>
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(250));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{DateTime.Now:mm:ss.fff}:{dt}");
    });
    
    var proc = new BufferBlock<Token>();
    proc.LinkTo(highPriority, dt => dt.Priority == Priority.High);
    proc.LinkTo(midPriority, dt => dt.Priority == Priority.Medium);
    proc.LinkTo(lowPriority, dt => dt.Priority == Priority.Low);
    tokens.Subscribe(dt => proc.Post(dt));
