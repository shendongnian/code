    var state = new SharedState();
    for (var count = 0; count < TestDates.Count; count++)
    {
        var date = TestDates[count];
        if (count % 25 == 0)
        {
            // runs on 0, 25, 50, ...
            ProcessPart1(state);
        }
        // runs on each iteration
        ProcessPart2(state);
    }
