    private void HandleLoaded(object sender, RoutedEventArgs e)
    {
        Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,
            new Action(() => changeRotation(...))); // wrap original HandleLoaded logic 
             
    }
