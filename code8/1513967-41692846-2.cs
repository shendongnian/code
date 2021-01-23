    private async Task<IEnumerable<Event>> GetEventsAsync(long length)
    {
        List<Event> events = new List<Event>();
        var pos = _reader.BaseStream.Position;
        while (_reader.BaseStream.Position - pos < length)
        {
            // if ReadEvent depends on _reader.BaseStream.Postion
            // you cannot use Task.WhenAll, because it executes all
            // tasks in parallel, where else, you must await to finish
            // your previous ReadEvent
            Event e = await ReadEvent(); // this method is async
            events.Add(e);
        }
        return events;
    }
