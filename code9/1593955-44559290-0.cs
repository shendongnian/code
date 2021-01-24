    await Task.Run(Navigate);
    private async Task Navigate()
    {        
        try
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                webView.Navigate(new Uri("http://www.google.com"));    
            });
        }
        catch (Exception e)
        {
            Debug.WriteLine("{0} Exception caught.", e);
        }
    }
