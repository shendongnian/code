    private void ThemeChanger_Click(object sender, RoutedEventArgs e)
    {
        App.BackgroundBrushColor = Windows.UI.Color.FromArgb(Convert.ToByte(random.Next(255)), Convert.ToByte(random.Next(255)), Convert.ToByte(random.Next(255)), Convert.ToByte(random.Next(255)));
    
        (Application.Current.Resources["BackgroundBrush"] as SolidColorBrush).Color = App.BackgroundBrushColor;
    }
    
    private async Task CreateNewViewAsync()
    {
        CoreApplicationView newView = CoreApplication.CreateNewView();
        int newViewId = 0;
    
        await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            (Application.Current.Resources["BackgroundBrush"] as SolidColorBrush).Color = App.BackgroundBrushColor;
    
            Frame frame = new Frame();
            frame.Navigate(typeof(SecondaryPage), null);
            Window.Current.Content = frame;
            // You have to activate the window in order to show it later.
            Window.Current.Activate();
    
            newViewId = ApplicationView.GetForCurrentView().Id;
        });
        bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
    }
