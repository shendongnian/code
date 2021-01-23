    private void UserControl_LostFocus(object sender, RoutedEventArgs e)
    {
        if(!dont && !txtUName.IsFocused && !IsFocused)
            MyPopup.IsOpen = false;
    }
