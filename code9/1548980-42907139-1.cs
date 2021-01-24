    static ManualResetEvent resetEventsGet(string key)
    {
        lock(resetEvents)
        {
            ManualResetEvent result;
            // lookup the key
            if(!resetEvents.TryGetValue(key, out result))
                // if it doesn't exists, create a new one.
                resetEvents.Add(key, result = new ManualResetEvent(false));
 
            return result;
        }
    }
