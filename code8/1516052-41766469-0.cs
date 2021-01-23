    private List<Event> GetRunningEvents(DateTime time)
    {
        List<Event> RunningEvents = new List<Event>();
        foreach(Event E in Events)
        {
            if (E.EventStartTime <= time && E.EventEndTime >= time)
            {
                RunningEvents.Add(E);
            }
        }
        return RunningEvents;
    }
