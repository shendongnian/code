    private async Task<IEnumerable<Event>> GetEventsAsync(long length)
    {
        List<Event> events = new List<Event>();
        var pos = _reader.BaseStream.Position;
        while (_reader.BaseStream.Position - pos < length)
        {
            Event e = await ReadEvent(); // this method is async
            events.Add(e);
        }
        return events;
    }
