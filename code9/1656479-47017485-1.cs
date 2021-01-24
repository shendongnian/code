    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        InstantiateNewControl();
    }
    private void InstantiateNewControl()
    {
        var tc = new TestControl();
        this.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,
            new Action(InstantiateNewControl));
    }
