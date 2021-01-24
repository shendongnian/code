        public async Task<IEnumerable<string>> GetRates()
        {
            var rates = new ConcurrentBag<Rate>();
            var tasks = rates.Where(carrier => carrier.Enabled)
                .Select(async carrier =>
                {
                    try
                    {
                        await Task.Run(async () =>
                        {
                            var t = await Task.Run(() => carrier.GetRates...
                            foreach (var item in t)
                            {
                                rates.Add(item);
                            }
                        });
                        
                    }
                    finally
                    {
                    }
                }); 
            await Task.WhenAll(tasks).ConfigureAwait(false);
            return rates;
        }
