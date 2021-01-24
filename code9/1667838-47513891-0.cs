    public static IObservable<long> Interval(TimeSpan interval)
    {
        return Observable.Create<long>(observer =>
        {
            long i = 0;
            Timer _timer = new Timer(interval.TotalMilliseconds);
            _timer.Elapsed += (s, e) => observer.OnNext(i++);
            _timer.Start();
            return Disposable.Create(() =>
            {
                _timer.Stop();
                _timer.Dispose();
            });
        });
    }
