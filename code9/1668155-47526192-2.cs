    class MockWebClient : IDisposable
    {
        private static readonly TimeSpan _kminDelay = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan _kmaxDelay = TimeSpan.FromSeconds(5);
        private static readonly Random _random = new Random();
        private static readonly object _lock = new object();
        private static TimeSpan _NextRandomDelay(TimeSpan min, TimeSpan max)
        {
            lock (_lock)
            {
                return TimeSpan.FromSeconds(
                    (max.TotalSeconds - min.TotalSeconds) * _random.NextDouble());
            }
        }
        private static bool _NextRandomBool()
        {
            lock (_lock)
            {
                return _random.Next(2) == 1;
            }
        }
        public async Task<string> DownloadStringAsync(string uri)
        {
            await Task.Delay(_NextRandomDelay(_kminDelay, _kmaxDelay));
            return _NextRandomBool() ? "live" : "dead";
        }
        public void Dispose()
        {
            // do nothing...it's a mock!
        }
    }
