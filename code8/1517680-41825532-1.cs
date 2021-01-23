    //The next code simulates data changes every 500 ms
    Timer = new Timer
    {
        Interval = 1000
    };
    Timer.Tick += TimerOnTick;
    var vg = new ValueGenerator( new Random( ) )
    {
        MinValue = 0,
        MaxValue = 5,
        MinInterval = 0.1,
        MaxInterval = 0.7,
        CurrentValue = 3.0,
        CurrentDirection = Direction.Decrease,
        PossibilityToChangeDirection = 10,
    };
    Timer.Start();
    
    ChartValues.Add(new MeasureModel
    {
        DateTime = now,
        Value = vg.NextValue(),
    });
