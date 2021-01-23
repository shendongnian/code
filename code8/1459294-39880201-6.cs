    private void headsButton_Click(object sender, RoutedEventArgs e)
    {
        coinImage.Source = (ImageSource)Resources["heads"];
    }
    private void tailsButton_Click(object sender, RoutedEventArgs e)
    {
        coinImage.Source = (ImageSource)Resources["tails"];
    }
