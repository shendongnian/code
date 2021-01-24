        private void throttle()
        {
            var maxPerPeriod = 250;
            //If you utilize multiple accounts, you can throttle per account. If not, don't use this:
            var keyPrefix = "a_unique_id_for_the_basis_of_throttling";
            var intervalPeriod = 300000;//5 minutes
            var sleepInterval = 5000;//period to "sleep" before trying again (if the limits have been reached)
            var recentTransactions = MemoryCache.Default.Count(x => x.Key.StartsWith(keyPrefix));
            while (recentTransactions >= maxPerPeriod)
            {
                System.Threading.Thread.Sleep(sleepInterval);
                recentTransactions = MemoryCache.Default.Count(x => x.Key.StartsWith(keyPrefix));
            }
            var key = keyPrefix + "_" + DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmm");
            var existing = MemoryCache.Default.Where(x => x.Key.StartsWith(key));
            if (existing != null && existing.Any())
            {
                var counter = 2;
                var last = existing.OrderBy(x => x.Key).Last();
                var pieces = last.Key.Split('_');
                if (pieces.Count() > 2)
                {
                    var lastCount = 0;
                    if (int.TryParse(pieces[2], out lastCount))
                    {
                        counter = lastCount + 1;
                    }
                }
                key = key + "_" + counter;
            }
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMilliseconds(intervalPeriod)
            };
            MemoryCache.Default.Set(key, 1, policy);
        }
