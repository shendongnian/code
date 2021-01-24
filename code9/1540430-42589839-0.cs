	var ts = new TestScheduler();
	var source = ts.CreateHotObservable<char>(
		new Recorded<Notification<char>>(200.MsTicks(), Notification.CreateOnNext('A')),
		new Recorded<Notification<char>>(300.MsTicks(), Notification.CreateOnNext('B')),
		new Recorded<Notification<char>>(500.MsTicks(), Notification.CreateOnNext('C')),
		new Recorded<Notification<char>>(510.MsTicks(), Notification.CreateOnNext('D')),
		new Recorded<Notification<char>>(550.MsTicks(), Notification.CreateOnNext('E')),
		new Recorded<Notification<char>>(610.MsTicks(), Notification.CreateOnNext('F')),
        new Recorded<Notification<char>>(760.MsTicks(), Notification.CreateOnNext('G'))
	);
	var target = source.ThrottleSubsequent(TimeSpan.FromMilliseconds(150), ts);
	var expectedResults = ts.CreateHotObservable<char>(
		new Recorded<Notification<char>>(200.MsTicks(), Notification.CreateOnNext('A')),
		new Recorded<Notification<char>>(450.MsTicks(), Notification.CreateOnNext('B')),
		new Recorded<Notification<char>>(500.MsTicks(), Notification.CreateOnNext('C')),
		new Recorded<Notification<char>>(910.MsTicks(), Notification.CreateOnNext('G'))
	);
	var observer = ts.CreateObserver<char>();
	target.Subscribe(observer);
	ts.Start();
	ReactiveAssert.AreElementsEqual(expectedResults.Messages, observer.Messages);
