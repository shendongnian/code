    public static class Global
    {
        public static int MaxCount { get; set; } = 30;
        public static TimeSpan Interval { get; set; } = TimeSpan.FromSeconds(1);
        private static object _lockObject = new object();
        private static TimeLimiter rateLimiter;
        public static TimeLimiter RateLimiter
        {
            get
            {
                lock (_lockObject)
                {
                    if (rateLimiter == null)
                        rateLimiter = TimeLimiter.GetFromMaxCountByInterval(MaxCount, Interval);
                    return rateLimiter;
                }
            }
        }
    }
