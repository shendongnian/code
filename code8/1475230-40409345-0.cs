    public static async string Run(string input, TraceWriter log)
    {
        log.Info($"C# manually triggered function called with input: {input}");
        await Task.Delay(1);
    
        return input;
    }
