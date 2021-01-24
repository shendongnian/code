    private Key key;
    private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        key = e.Key;
        if (key == Key.Enter)
        {
            UIElement element = e.OriginalSource as UIElement;
            element.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
    }
    private void txt2_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        if (key == Key.Enter)
        {
            CalculateSomethingFromOtherTextBoxes();
        }
    }
