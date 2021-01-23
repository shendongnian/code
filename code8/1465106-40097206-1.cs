    var ob = Observable.Interval(TimeSpan.FromSeconds(1)).StartWith(500).Replay(1).RefCount();
    ob.Subscribe(); // Subscribe to start the above hot observable immediately.
    Observable.Timer(TimeSpan.FromSeconds(5)).Subscribe(x =>
    {
    	ob.First().Dump(); 
        // This would give you either 3 or 4, depending on the speed and timing of your computer.
    });
