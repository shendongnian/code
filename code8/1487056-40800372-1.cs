    [Test]
    public void RepeatedTimeout()
    {
        var scheduler = new TestScheduler();
        var events = scheduler.CreateHotObservable(
            OnNext(4, 1),
            OnNext(7, 2),
            OnNext(10, 3),
            OnNext(14, 4),
            OnNext(30, 5),
            OnNext(35, 6),
            OnCompleted<int>(36)
            );
        var timespan = TimeSpan.FromTicks(5);
        var timeoutEvent = -1;
        var groups = RepeatingTimeout(events, timespan, timeoutEvent, scheduler);
        groups.Do(x => Console.WriteLine("G " + scheduler.Clock + " " + x));
        var results = scheduler.Start(() => groups, 0, 0, 100);
    }
