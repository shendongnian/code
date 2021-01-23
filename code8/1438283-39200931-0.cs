    private async void Test_Click(object sender, RoutedEventArgs e)
    {
        var currentAV = ApplicationView.GetForCurrentView();
        //get the bounds of current window.
        var rect = Window.Current.Bounds;
        var newAV = CoreApplication.CreateNewView();
        await newAV.Dispatcher.RunAsync(
                        CoreDispatcherPriority.Normal,
                        async () =>
                        {
                            var newWindow = Window.Current;
                            var newAppView = ApplicationView.GetForCurrentView();
                            newAppView.Title = "New window";
    
                            var frame = new Frame();
                            //send current window's size as parameter.
                            frame.Navigate(typeof(MainPage), rect.Width.ToString() + ":" + rect.Height.ToString());
                            newWindow.Content = frame;
                            newWindow.Activate();
    
                            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                                newAppView.Id,
                                ViewSizePreference.UseHalf,
                                currentAV.Id,
                                ViewSizePreference.UseHalf);
                        });
    }
