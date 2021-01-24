    private readonly AsyncLock _lock = new AsyncLock();
    
    public Textbox_TextChangedEvent()
    {
        GetStocks(texboxText); // every call is now "queued" after the previous one
    }
    
    public async Task GetStocks(string texboxText)
    {
        using(await _lock.EnterAsync())
        {
            IsBusy = true;
            await Task.Run(() => { CreateCollection(texboxText); });
            IsBusy = false;
        }
    }
