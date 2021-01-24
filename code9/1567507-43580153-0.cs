    private async void InstallButton_Click(object sender, RoutedEventArgs e)
    {
        await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
        {
            bool installed = await FileManager.InstallAsync(StorageLocation.Local);
        });
    }
  
