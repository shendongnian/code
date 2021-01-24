    private void SelectedAddress_Click(object sender, RoutedEventArgs e)
    {
        Border border = sender as Border;
        object dodo = border.DataContext;
        string address = dodo as string;
        if (!string.IsNullOrEmpty(address))
        {
            //...
        }
    }
