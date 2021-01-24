    // Part of your Composition Root
    public static AsyncLocal<TextWriter> Writer = new AsyncLocal<TextWriter>();
    // Registration
    container.Register<ILogger>(() => new MyLogger(
        Writer ?? (container.IsVerifying ? new TextWriter() : null)));
    // Assign the log to the CurrentWriter at the start of the request
    public Task MyQueueHandler(TextWriter log)
    {
        CompositionRoot.CurrentWriter = log;
        // execute rest of request
    }  
