    public override bool DeleteData()
    {
        SomeSharedMethodAsync().ConfigureAwait(false).Wait();
        UpdateUI();
    }
    async Task SomeSharedAsyncMethod()
    {
        // do all async stuff here, but DON'T update the UI
        await Task.Delay(2000).ConfigureAwait(false);
    }
    void UpdateUI()
    {
         // update the UI here
         SomeTextBox.Text = "Some Text";
    }
