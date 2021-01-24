    public async Task<IEnumerable<Rate>> GetRates(
        Address originAddress, Address destinationAddress, Package package)
    {
        List<Task<Rate[]>> mappedTasks = Carriers
            .Where(c => c.Enabled)
            .Select(carrier => ProcessOneCarrier(
                carrier, originAddress, destinationAddress, package))
            .ToList();
    
        List<Rate> reducedResults = new List<Rate>();
    
        foreach (var task in mappedTasks.AsItCompletes())
        {
            Rate[] rates = await task;
            if (task.Exception != null)
            {
                // Handle Exception
            }
            reducedResults.AddRange(rates);           
        }
    
        return reducedResults;
    }
    
    async Task<Rate[]> ProcessOneCarrier(
        Carrier carrier, Address originAddress, Address destinationAddress, Package package)
    {
        var rates = await carrier.GetRates(originAddress, destinationAddress, package);
        return rates.ToArray();
    }
