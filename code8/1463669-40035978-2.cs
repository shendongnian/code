    private void App_BackRequested(object sender,
        Windows.UI.Core.BackRequestedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame == null)
            return; 
        if (rootFrame.CanGoBack && e.Handled == false)
        {
            e.Handled = true;
            rootFrame.GoBack();
        }
    }
