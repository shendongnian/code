    var transitions = new[]
    {
        new Transition<char>{From = S1, To = S2, EventMatcher = c => c == 'b', Guard = null },
        new Transition<char>{From = S2, To = S1, EventMatcher = c => c == 'a', Guard = null },
    };
