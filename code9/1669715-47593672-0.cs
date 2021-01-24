    private static ConcurrentDictionary<string, Lazy<TimeLimiter>> ratelimiters = new ConcurrentDictionary<string, Lazy<TimeLimiter>>();
    
    public static TimeLimiter GetRateLimiterForClient(string clientId)
    {
        return ratelimiters.GetOrAdd(clientId, c => 
                new Lazy<TimeLimiter>(() =>
                    TimeLimiter.GetFromMaxCountByInterval(MaxCount, Interval)))
                    .Value;
    }
