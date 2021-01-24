    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        // Attach a handler to process the received advertisement. 
        // The watcher cannot be started without a Received handler attached
        watcher.Received += OnAdvertisementReceived;
        watcher.Stopped += OnAdvertisementWatcherStopped;
    }
    private async void OnAdvertisementWatcherStopped(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementWatcherStoppedEventArgs args)
    {
        await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            txtresult.Text = string.Format("Watcher stopped or aborted: {0}", args.Error.ToString());
        });
    }
