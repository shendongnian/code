    private async void ClickHandler(object sender, EventArgs args)
    {
        bool checked = await SomeAsyncWorkThatReturnsBool().ConfigureAwait(false);
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => checkbox.IsChecked = checked);
    }
