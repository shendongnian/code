    protected override async Task<bool> Test()
    {
        Websocket ws = new Websocket();
        ws.ProcessRequest(context);
        await Task.Delay(1000); // notice the awaitable Delay replacing the blocking Sleep.
        logger.Write("Async method ");
        var task = await DoRespond(context);
    }
