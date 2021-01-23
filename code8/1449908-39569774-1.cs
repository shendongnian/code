    var state = new SharedState();
    for (var count = 0; count < TestDates.Count; count++)
    {
        var date = TestDates[count];
        if (count % 25 == 0)
        {
            // runs on 0, 25, 50, ...
            Process1(state);
        }
        // runs on each iteration
        Process2(state);
    }
