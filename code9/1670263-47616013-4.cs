    private async void CoreWindow_SizeChanged(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.WindowSizeChangedEventArgs args)
    {
        var appView = ApplicationView.GetForCurrentView();
        if (!appView.IsFullScreen)
        {
            var messageDialog = new MessageDialog("Window is not Maximized");
            await messageDialog.ShowAsync();
        }
        args.Handled = true;
        if (appView.IsFullScreen)
        {
            var messageDialog = new MessageDialog("Window is Maximized");
            await messageDialog.ShowAsync();
        }
        args.Handled = true;
    }
