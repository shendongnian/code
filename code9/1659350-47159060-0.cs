    private void OnRoutedEvent(object sender, RoutedEventArgs e)
    {
        FrameworkElement fe = sender as FrameworkElement;
        if (fe != null && fe.Name == "textBoxId")
        {
            //...
        }
    }
