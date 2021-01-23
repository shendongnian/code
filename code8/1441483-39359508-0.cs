    public IObservable<Unit> GetInactivityObservable()
    {
        return _inactivityObservable = _inactivityObservable ??
            Observable.FromEventPattern<EventHandler<EventArgs>, EventArgs>(
                h => _activitySource.Activity += h,
                h => _activitySource.Activity -= h)
                .Sample(TimeSpan.FromSeconds(1), _schedulerProvider.NewThread)
                .Select(_ => Unit.Default)
                .Publish()
                .RefCount();
    }
