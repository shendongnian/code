    public IObservable<Unit> GetInactivityObservable()
    {
        return _inactivityObservable = _inactivityObservable ??
            Observable.FromEventPattern<EventHandler<EventArgs>, EventArgs>(
                h => _activitySource.Activity += h,
                h => _activitySource.Activity -= h)
                .Select(_=>Unit.Default)
                .StartWith(Unit.Default)
                .Sample(TimeSpan.FromSeconds(1), _schedulerProvider.NewThread)
                .Select(a=>Observable.Timer(TimeSpan.FromSeconds(1), _schedulerProvider.NewThread).Select(_=>Unit.Default))
		        .Switch()
                .Publish()
                .RefCount();
    }
