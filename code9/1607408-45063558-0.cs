    private void IntializeSpikeStream()
        {
            var current = Observable.Interval(TimeSpan.FromSeconds(FastPeriod))
                 .Select(_ => GetLastPrice()).Publish();
            var normal = Observable.Interval(TimeSpan.FromSeconds(SlowPeriod))
                 .Select(_ => GetLastPrice()).Delay(TimeSpan.FromSeconds(FastPeriod)).Publish();
            ts1Subscription1 = current.Connect();
            ts1Subscription2 = normal.Connect(); 
            var stream = current.CombineLatest(normal, (a, b) => (a - b) / a)
                .Where(diffPercent => diffPercent != PercentDiff)
                .Select(ratePercent => new SpikeIndicatorValues { PercentRate = ratePercent }).Publish();
            spikeSubscription = stream.Connect();
            Stream = stream;            
        }
        public void Dispose()
        {
            spikeSubscription?.Dispose();
            ts1Subscription1.Dispose();
            ts1Subscription2.Dispose();
        }
