    Observable.FromEventPattern<EventArgs>(_listener, "EventHandler", System.Reactive.Concurrency.NewThreadScheduler.Default)
                .Distinct(x => x.EventArgs.Key)
                .Sample(TimeSpan.FromSeconds(1))
                .Subscribe(x1 =>
                {
                        updateSubject.OnNext(x1.EventArgs.NewValue);
                });
