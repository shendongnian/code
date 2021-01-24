    protected override async Task<bool> Test()
    {
        using (Websocket ws = new Websocket()) // properly dispose of WebSocket
        {
            ws.ProcessRequest(context);
            await Task.Delay(1000); // notice the awaitable Delay replacing the blocking Sleep.
            logger.Write("Async method ");
            await DoRespond(context);
        }
    }
