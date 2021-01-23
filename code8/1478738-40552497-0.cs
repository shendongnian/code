    private object selectedItem = null;
    private void Currency_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (Currency.SelectedItem == selectedItem)
            return;
        Currency.IsDropDownOpen = false;
        MessageBoxResult result = MessageBox.Show("Are you sure you want to change the currency?",
               "Warning",
               MessageBoxButton.OKCancel,
               MessageBoxImage.Question);
        if (result == MessageBoxResult.Cancel)
            Currency.SelectedItem = selectedItem;
        else
            selectedItem = Currency.SelectedItem;
    }
