    await Task.Run(Navigate);
    private async Task Navigate()
    {        
        try
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                webView.Navigate(new Uri("http://www.google.com"));    
            });
        }
        catch (Exception e)
        {
            Debug.WriteLine("{0} Exception caught.", e);
        }
    }
