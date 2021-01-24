    public async Task<IEnumerable<Rate>> GetRates(Address originAddress, Address destinationAddress,Package package)
    {
        var rates = new List<Rate>();
        var tasks = Carriers.Where(carrier => carrier.Enabled)
            .Select(async carrier => 
            {
                try
                {
                    return carrier.GetRates(originAddress, destinationAddress, package);
                }
                finally
                {
                }
            });
    
         await Task.WhenAll(tasks).ConfigureAwait(false);
                foreach (var item in tasks)
                {
                    rates.AddRange(item.Result);
                }
        return rates;
    }
