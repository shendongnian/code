    [Fact]
    public void ShouldIterateThroughStringsEveryFiveSeconds()
    {
        TestScheduler scheduler = new TestScheduler();
    
        string[] messages = new[]
        {
                    "Welcome",
                    "We are settings things up for you",
                    "This may take a little while first time"
        };
    
        var expected = new[]
        {
            ReactiveTest.OnNext(ReactiveTest.Subscribed + TimeSpan.FromSeconds(0).Ticks, "Welcome"),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + TimeSpan.FromSeconds(5).Ticks, "We are settings things up for you"),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + TimeSpan.FromSeconds(10).Ticks, "This may take a little while first time"),
            ReactiveTest.OnCompleted<string>(ReactiveTest.Subscribed + TimeSpan.FromSeconds(15).Ticks)
        };
    
        var actual = scheduler.Start(
            // Solution
            () => Observable.Zip(
                messages.ToObservable(),
                Observable.Interval(TimeSpan.FromSeconds(5), scheduler).StartWith(0),
                (text, time) => text),
            TimeSpan.FromSeconds(20).Ticks
        );
    
        Assert.Equal(expected, actual.Messages.ToArray());
    }
