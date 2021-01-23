    private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
    {
        LsbPopup.PlacementTarget = sender as TextBox;
        LsbPopup.IsOpen = true;
    }
    private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
    {
        LsbPopup.IsOpen = false;
    }
