    // Transform the PropertyChanged event in an Observable
    var changed = Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
        h => PropertyChanged += h,
        h => PropertyChanged -= h);
    // Transform the Observable to your need,
    // filtering only when SearchText changes
    changed.Where(x => x.EventArgs.PropertyName == nameof(SearchText))
    // Wait 500 ms before forwarding the notification;
    // if another char in inserted from the user beside this interval,
    // the previous value is ignored
    .Throttle(TimeSpan.FromMilliseconds(500))
    // Necessary to avoid cross-thread Exceptions
    .ObserveOn(Scheduler.CurrentThread)
    // finally, subscribe your method:
    .Subscribe(_ => MyMethod());
    
