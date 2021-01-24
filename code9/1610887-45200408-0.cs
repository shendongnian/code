    Observable.FromEventPattern<EventArgs>(_listener, "EventHandler", System.Reactive.Concurrency.NewThreadScheduler.Default)
                .GroupBy(x => x.EventArgs.Key)
                .Subscribe(g =>
                {
                    g.Sample(TimeSpan.FromSeconds(1))
                    .Subscribe(x1 =>
                    {
                        updateSubject.OnNext(key);
                    });
                });
    
    updateSubject
    .SubscribeOn(NewThreadScheduler.Default)
    .ObserveOn(NewThreadScheduler.Default)
    .Subscribe(EventHandler); //Event Handler is the what gets called to handle the events 
