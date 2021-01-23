    public void OnTimingsRecieved(double ticks)
    {
        for (int i = 0; i < _observers.Count; i++)
        {
            var count = _observers.Count;  // save count in case it may change.
            var observer = _observers[i];
            observer.OnNext(ticks);        // it may only dispose it self.
            i -= count - _observers.Count; // decrement if observer unsubscribed.
        }
    }
