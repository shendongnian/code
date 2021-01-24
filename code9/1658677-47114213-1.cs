    private void button1_Click(object sender, EventArgs e)
    {
        button1.Text = "Starting...";
    
        var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
        Task.Factory.StartNew(() => CheckIfFileExists(uiScheduler));
    }
    
    private async Task CheckIfFileExists(TaskScheduler uiScheduler)
    {
        await Task.Delay(2000);
    
        var exists = true; // check if exists
    
        await Task.Factory.StartNew(() => UpdateText(exists), CancellationToken.None, TaskCreationOptions.None, uiScheduler).ConfigureAwait(false);
    }
    
    private void UpdateText(bool exists)
    {
        button1.Text = $"Exists: {exists}.";
    }
