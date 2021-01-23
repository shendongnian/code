    private async Task<EventManager> ReadEventManagerAsync()
    {
        // some other stuff
        var length = Reverse(await _reader.ReadInt32()); // bytes to read
        var events = GetEventsAsync(length); // cant await iterator. so use linq
        await Task.WhenAll(events);
        return new EventManager(events.Select(x => x.Result));
    }
