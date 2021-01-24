    private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        Window.Current.CoreWindow.SizeChanged += async (ss, ee) =>
        {
            var appView = ApplicationView.GetForCurrentView();
            if (appView.IsFullScreen)
            {
                var messageDialog = new MessageDialog("Window is in full screen");
                await messageDialog.ShowAsync();
            }
            ee.Handled = true;
        };
        Window.Current.CoreWindow.SizeChanged += async (ss, ee) =>
        {
            var appView = ApplicationView.GetForCurrentView();
            if (!appView.IsFullScreen)
            {
                var messageDialog = new MessageDialog("window is not in full screen");
                await messageDialog.ShowAsync();
            }
            ee.Handled = true;
        };
    }
