    //Code for Hiding your app bar
    private void UserControl_RightTapped(object sender, RoutedEventArgs e)
    {
        appBarName.Visibility = Visibility.Collapsed;
    }
    
    //Code for showing your app bar
    private void UserControl_RightTapped(object sender, RoutedEventArgs e)
    {
        appBarName.Visibility = Visibility.Visible;
    }
