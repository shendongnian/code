	var scheduler = new TestScheduler();
	var source = scheduler.CreateColdObservable(
		ReactiveTest.OnNext(100, 1),
		ReactiveTest.OnNext(200, 2),
		ReactiveTest.OnNext(300, 3),
		ReactiveTest.OnNext(400, 4),
		ReactiveTest.OnNext(500, 5),
		ReactiveTest.OnNext(600, 6),
		ReactiveTest.OnNext(700, 7),
		ReactiveTest.OnNext(800, 8),
		ReactiveTest.OnNext(900, 9),
		ReactiveTest.OnNext(1000, 10),
		ReactiveTest.OnNext(1100, 11)
        );
		
	var router = source.GroupBy(i=>i%4)
		.Publish()
		.RefCount();
	
	var zerosObserver = scheduler.CreateObserver<int>();
	router.Where(grp=>grp.Key == 0)
		.Take(1)
		.SelectMany(grp=>grp)
		.Subscribe(zerosObserver);
	var onesObserver = scheduler.CreateObserver<int>();
	router.Where(grp => grp.Key == 1)
		.Take(1)
		.SelectMany(grp => grp)
		.Subscribe(onesObserver);
	var twosObserver = scheduler.CreateObserver<int>();
	router.Where(grp => grp.Key == 2)
			.Take(1)
			.SelectMany(grp => grp)
			.Subscribe(twosObserver);
	var threesObserver = scheduler.CreateObserver<int>();
	router.Where(grp => grp.Key == 3)
			.Take(1)
			.SelectMany(grp => grp)
			.Subscribe(threesObserver);
			
	scheduler.Start();
	ReactiveAssert.AreElementsEqual(new[] { ReactiveTest.OnNext(400, 4), ReactiveTest.OnNext(800, 8)}, zerosObserver.Messages);
	ReactiveAssert.AreElementsEqual(new[] { ReactiveTest.OnNext(100, 1), ReactiveTest.OnNext(500, 5), ReactiveTest.OnNext(900, 9)}, onesObserver.Messages);
	ReactiveAssert.AreElementsEqual(new[] { ReactiveTest.OnNext(200, 2), ReactiveTest.OnNext(600, 6), ReactiveTest.OnNext(1000, 10) }, twosObserver.Messages);
	ReactiveAssert.AreElementsEqual(new[] { ReactiveTest.OnNext(300, 3), ReactiveTest.OnNext(700, 7), ReactiveTest.OnNext(1100, 11)}, threesObserver.Messages);
