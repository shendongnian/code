    [Fact]
    public void MatchExpected()
    {
        TestScheduler scheduler = new TestScheduler();
    
        // 0        1         2         3         4 
        // 1234567890123456789012345678901234567890
        // a-------b-cd-----e---------f-----ghX     <- Input
        IObservable<char> input = scheduler.CreateColdObservable(
            ReactiveTest.OnNext(1, 'a'),
            ReactiveTest.OnNext(9, 'b'),
            ReactiveTest.OnNext(11, 'c'),
            ReactiveTest.OnNext(12, 'd'),
            ReactiveTest.OnNext(18, 'e'),
            ReactiveTest.OnNext(28, 'f'),
            ReactiveTest.OnNext(34, 'g'),
            ReactiveTest.OnNext(35, 'h'),
            ReactiveTest.OnCompleted<char>(36)
        );
    
        // 0        1         2         3         4 
        // 1234567890123456789012345678901234567890
        // a-------b-cd-----e---------f-----ghX     <- Input
        // a-------b---c---d---e------f-----g---hX  <- Expected
        var expected = new []
        {
            ReactiveTest.OnNext(ReactiveTest.Subscribed + 1, 'a'),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + 9, 'b'),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + 13, 'c'),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + 17, 'd'),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + 21, 'e'),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + 28, 'f'),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + 34, 'g'),
            ReactiveTest.OnNext(ReactiveTest.Subscribed + 38, 'h'),
            ReactiveTest.OnCompleted<char>(ReactiveTest.Subscribed + 38)
        };            
    
        var actual = scheduler.Start(() => input.Separate(TimeSpan.FromTicks(4), scheduler), ReactiveTest.Subscribed + 40);
    
        Assert.Equal(expected, actual.Messages.ToArray());
    }
