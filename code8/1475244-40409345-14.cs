    public static async Task Run(string input, IAsyncCollector<string> collection, TraceWriter log)
    {
        log.Info($"C# manually triggered function called with input: {input}");
        await collection.AddAsync(input);
    }
