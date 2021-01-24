    public void DoStuff()
    {
        FireAndForgetAsync();
    }
        
    private async void FireAndForgetAsync()
    {
        await Task.Delay(1000);
        throw new Exception(); //will be swallowed
    }
