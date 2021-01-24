    static ManualResetEvent resetEventsGet(string key)
    {
        lock(resetEvents)
        {
            ManualResetEvent result;
            if(!resetEvents.TryGetValue(key, out result))
                resetEvents.Add(key, result = new new ManualResetEvent(false));
 
            return result;
        }
    }
