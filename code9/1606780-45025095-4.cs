    IObservable<EventPattern<MouseEventArgs>> mouseMoves =
            Observable
                .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                    h => this.MouseMove += h,
                    h => this.MouseMove -= h);
    IDisposable subscription =
        mouseMoves
            .ObserveOn(Scheduler.Default)
            .Do(ep =>
            {
                Console.WriteLine("Th" + Thread.CurrentThread.ManagedThreadId);
            })
            .ObserveOn(this)
            .Subscribe(ep =>
            {
                Console.WriteLine("UI" + Thread.CurrentThread.ManagedThreadId);
            });
    Console.WriteLine("!" + Thread.CurrentThread.ManagedThreadId);
