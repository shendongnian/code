    public async Task MyAsyncMethod()
    {
        MySyncMethod();
        await TrulyAsyncFoo();
        MyOtherSyncMethod();
    }
