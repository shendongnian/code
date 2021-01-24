    private void Button1_Click(object sender, RoutedEventArgs e)
    {
        bool isVisible = Container1.Visibility == Visibility.Visible;
        Container1.Visibility = isVisible ? Visibility.Hidden : Visibility.Visible;
    }
    
    private void Button2_Click(object sender, RoutedEventArgs e)
    {
        bool isVisible = Container2.Visibility == Visibility.Visible;
        Container1.Visibility = isVisible ? Visibility.Hidden : Visibility.Visible;
    }
