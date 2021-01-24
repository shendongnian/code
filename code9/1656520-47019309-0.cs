    async void Click(object sender, RoutedEventArgs e)
    {
        ErrorPanel.Visibility = Visibility.Visible;
        var products = await Task.Run(() => Communication.GetProductList(tempPznList));
        mainPznItem.SubPzns = products;
        ErrorPanel.Visibility = Visibility.Hidden;
    }
