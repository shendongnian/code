    var highPriority = new ActionBlock<Token>(dt =>
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(250));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{DateTime.Now:mm:ss.fff}:{dt}");
    });
    var midPriority = new ActionBlock<Token>(dt =>
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(250));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{DateTime.Now:mm:ss.fff}:{dt}");
    });
    
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
