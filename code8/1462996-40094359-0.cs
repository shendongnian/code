    var source = Observable.Interval(TimeSpan.FromSeconds(1));
    var queue = new BroadcastBlock<long>(null);
    var subscription = queue.AsObservable().DistinctUntilChanged().Subscribe(l =>
    {
        Thread.Sleep(2500);
        Console.WriteLine(l);
    });
    source.SubscribeOn(ThreadPoolScheduler.Instance).Subscribe(queue.AsObserver());
