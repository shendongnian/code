    private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        Window.Current.CoreWindow.SizeChanged += async (ss, ee) =>
        {
            var appView = ApplicationView.GetForCurrentView();
            if (appView.IsFullScreen)
            {
                var messageDialog = new MessageDialog("Window is Maximized");
                await messageDialog.ShowAsync();
            }
            ee.Handled = true;
        };
        Window.Current.CoreWindow.SizeChanged += async (ss, ee) =>
        {
            var appView = ApplicationView.GetForCurrentView();
            if (!appView.IsFullScreen)
            {
                var messageDialog = new MessageDialog("Window is not Maximized");
                await messageDialog.ShowAsync();
            }
            ee.Handled = true;
        };
    }
