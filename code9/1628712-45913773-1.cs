    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        newView = CoreApplication.CreateNewView();
        int newViewId = 0;
        await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            var id = Environment.CurrentManagedThreadId;
            Frame frame = new Frame();
            frame.Navigate(typeof(SecondPage), null);
            Window.Current.Content = frame;
    
            Window.Current.Activate();
    
            newViewId = ApplicationView.GetForCurrentView().Id;
        });
        bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
    }
    
    private async void SendBtn_Click(object sender, RoutedEventArgs e)
    {
        await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            var id = Environment.CurrentManagedThreadId;
            Messenger.Default.Send("Test send message!!!");
        });
    }
