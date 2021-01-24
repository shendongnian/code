    private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (!initialized)
        {
            loadList();
            initialized = true;
        }
    }
