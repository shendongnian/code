    private void FirstClick(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(MultiPage), PageType.First);
    }
    private void SecondClick(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(MultiPage), PageType.Second);
    }
