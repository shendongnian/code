    public async void YourMethodAsync()
    {
        if (e.Key == Key.Delete)
        {
            //Could I show window here like like "Loading please wait.."
            await CorrectWayAsync();
            //When this is done close this method
        }
    }
    public async Task CorrectWayAsync()
    {
        await Task.Run(() => { ExecuteLongMethod(); });
    }
