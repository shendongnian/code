    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame.CanGoBack)
        {
            e.Handled = true;
            rootFrame.GoBack();
        }
    }
