    public async void Run(IBackgroundTaskInstance taskInstance)
    {
        var differal = taskInstance.GetDeferral();
        await UpdateUI();
        differal.Complete();
    }
    public async Task UpdateUI()
    {
        ...
    }
