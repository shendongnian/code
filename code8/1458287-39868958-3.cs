    private void Back_Button_Click(object sender, RoutedEventArgs e)
    {
        if (SubPageFrame.CanGoBack)
            SubPageFrame.GoBack();
        else
        {
            SubPageFrame.Content = null;
            SubPageFrame.Visibility = Visibility.Collapsed;
            BasicContentScrollViewer.Visibility = Visibility.Visible;
        }
    }
    
    private void Forward_Button_Click(object sender, RoutedEventArgs e)
    {
        SubPageFrame.Navigate(typeof(MainPage));
        BasicContentScrollViewer.Visibility = Visibility.Collapsed;
        SubPageFrame.Visibility = Visibility.Visible;
    }
