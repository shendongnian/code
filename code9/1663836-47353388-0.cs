    hLinkButton.PointerEntered += hLinkButton_OnPointerEntered;
    private void hLinkButton_OnPointerEntered(object sender, PointerRoutedEventArgs e)
    {
        var hLButton = sender as HyperlinkButton;
        hLButton.Background = new SolidColorBrush(Colors.White);
        hLButton.Foreground = new SolidColorBrush(Colors.Red);
        hLButton.FontSize = 30.0;
    }
