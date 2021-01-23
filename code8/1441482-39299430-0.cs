    public IObservable<Unit> ObserveInactivity(TimeSpan inactivityTimeout)
    {
        return GetInactivityObservable()
            .StartWith(Unit.Default)  // <--
            .Select(_ => Observable.Interval(inactivityTimeout, _schedulerProvider.NewThread)
                    .Timestamp()
                    .Select(__ => Unit.Default))
            .Switch();
    }
