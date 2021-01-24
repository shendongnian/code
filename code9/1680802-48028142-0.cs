    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        CoreApplicationView newView = CoreApplication.CreateNewView();
        int newViewId = 0;
        await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            Frame frame = new Frame();
            frame.Navigate(typeof(SecondaryPage), null);   
            Window.Current.Content = frame;
            // You have to activate the window in order to show it later.
            Window.Current.Activate();
    
            newViewId = ApplicationView.GetForCurrentView().Id;
        });
        bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
    }
