    public override async Task OnConnected()
    {
        var result = await MyAsyncMethod();
        await base.OnConnected();
    }
