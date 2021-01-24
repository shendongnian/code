    private void AppBarButton_Click(object sender, RoutedEventArgs e)
    {
        la1.Visibility = Visibility.Visible;
        if(la1.IsEnabled == false)
        {
            la1.Foreground = (SolidColorBrush)Application.Current.Resources["AppBarButtonForegroundDisabled"];
        }
    }
