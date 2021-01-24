    internal void HandleMessage()
    {
        try
        {
            var parcel = await InputQueue.ReceiveAsync(timeSpan);
            // handle parsel
        }
        catch(InvalidOperationException x)
        {
        }
    }
