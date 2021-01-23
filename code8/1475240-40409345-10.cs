    public static async Task Run(string input, ICollectorAsync<string> collection, TraceWriter log)
    {
        log.Info($"C# manually triggered function called with input: {input}");
        await collection.AddAsync(input);
    }
