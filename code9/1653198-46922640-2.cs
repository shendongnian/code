    private async Task  DisplayProgess(string message)
    {
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {                
            lsvInvSynchProgress.Items.Add($"{message} - {DateTime.Now}");
         });
    }
