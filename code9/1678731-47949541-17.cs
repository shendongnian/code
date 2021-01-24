    private async Task<Dictionary<string, CalculationResult>> ProcessCombinations()
    {
        Dictionary<string, CalculationResult> combinations = new Dictionary<string, CalculationResult>();
        // do the processing
        // here we should do something that worth using concurrency
        // like querying databases, consuming APIs/WebServices, and other I/O stuff
        for (int i = 0; i < 950000; i++)
            combinations[i.ToString()] = new CalculationResult(new decimal[] { 1, 10, 15 });
        return await Task.FromResult(combinations);
    }
