    public async Task<IEnumerable<Rate>> GetRates(
        Address originAddress, Address destinationAddress, Package package)
    {
        List<Task<Rate[]>> mappedTasks = Carriers
            .Where(c => c.Enabled)
            .Select(carrier => ProcessOneCarrier(
                carrier, originAddress, destinationAddress, package))
            .ToList();
        List<Rate> reducedResults = new List<Rate>();
        while (mappedTasks.Count > 0)
        {
            var finishedTask = await Task.WhenAny(mappedTasks);
            Rate[] rates = await finishedTask;
            reducedResults.AddRange(rates);
            mappedTasks.Remove(finishedTask);
        }
        return reducedResults;
    }
    async Task<Rate[]> ProcessOneCarrier(
        Carrier carrier, Address originAddress, Address destinationAddress, Package package)
    {
        var rates = await carrier.GetRates(originAddress, destinationAddress, package);
        return rates.ToArray();
    }
