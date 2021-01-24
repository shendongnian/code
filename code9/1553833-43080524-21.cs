    TransitionBase<char>[] transitions = new[]
    {
        new SingleEventTransition<char>{From = S1, To = S2, Event = 'b', Guard = null },
        new MultiEventTransition<char>{From = S2, To = S1, Events = new TEvent[]{ 'e', 'f'},
                                       Guard = null },
    };
