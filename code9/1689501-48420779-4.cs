    [Fact]
    public void ObserveDistinctNonDistinct()
    {
        var scheduler = new TestScheduler();
        var source = scheduler.CreateHotObservable(
            OnNext(100, "a"),
            OnNext(110, "b"),
            OnNext(200, "a"),
            OnNext(220, "c"),
            OnNext(221, "a")
        ).Publish();
        var distinctResults = scheduler.CreateObserver<string>();
        source
            .Distinct()
            .Subscribe(distinctResults);
        var nonDistinctResults = scheduler.CreateObserver<string>();
        (from letter in source
            group letter by letter
            into groupedLetters
            from count in groupedLetters
                .Window(Observable.Never<string>())
                .SelectMany(ol =>
                    ol.Scan(0, (c, _) => ++c))
            where count > 1
            select groupedLetters.Key)
        .Distinct()
        .Subscribe(nonDistinctResults);
        source.Connect();
        scheduler.AdvanceBy(1000);
        distinctResults.Messages.AssertEqual(OnNext(100, "a"), OnNext(110, "b"), OnNext(220, "c"));
        nonDistinctResults.Messages.AssertEqual(OnNext(200, "a"));
    }
