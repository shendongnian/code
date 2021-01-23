    [Fact]
    public void ShouldIterateThroughStringsEveryFiveSecondsProvidingStringAndOpacity()
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
            ReactiveTest.OnNext(ReactiveTest.Subscribed + TimeSpan.FromSeconds(0).Ticks, Tuple.Create("Welcome", 0.0)),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + TimeSpan.FromSeconds(5).Ticks, Tuple.Create("We are settings things up for you", 0.5)),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + TimeSpan.FromSeconds(10).Ticks, Tuple.Create("This may take a little while first time", 1.0)),
            ReactiveTest.OnCompleted<Tuple<string, double>>(ReactiveTest.Subscribed + TimeSpan.FromSeconds(15).Ticks)
        };
    
        var actual = scheduler.Start(
            // Solution
            () => Observable
                .Zip(
                    messages.ToObservable(), 
                    Observable.Interval(TimeSpan.FromSeconds(5), scheduler).StartWith(0),
                    (text, time) => text)
                .Select((text, index) => Tuple.Create(text, Convert.ToDouble(index) / Convert.ToDouble(messages.Length - 1))),
            TimeSpan.FromSeconds(20).Ticks
        );
    
        Assert.Equal(expected, actual.Messages.ToArray());
    }
