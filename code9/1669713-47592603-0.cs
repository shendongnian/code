    private static Dictionary<string, Lazy<TimeLimiter>> ratelimiters = new Dictionary<string, Lazy<TimeLimiter>>();
    
    public static TimeLimiter GetRateLimiterForClient(string clientId)
    {
        if (!rateLimiters.ContainsKey(clientId))
        {
            rateLimiters.Add(clientId, 
                new Lazy<TimeLimiter>(() => 
                    TimeLimiter.GetFromMaxCountByInterval(MaxCount, Interval)));
        }
        return rateLimiters[clientId].Value;
    }
