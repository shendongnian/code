    void OnBackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
    {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CurrentSourcePageType == typeof(Pages.Home))
            {
                // ignore the event. We want the default system behavior
                e.Handled = false;
            }
            if (rootFrame.CanGoBack)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
    }
