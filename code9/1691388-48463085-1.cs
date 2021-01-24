    public void CxmOpened(Object sender, RoutedEventArgs args)
    {
        // Only allow menu item if something is selected
        if (cxmTextBox.SelectedText == "")
            cxmItemContains.IsEnabled = cxmItemNotContains.IsEnabled = false;
        else
            cxmItemContains.IsEnabled = cxmItemNotContains.IsEnabled = true;
    
        // Only allow paste if there is text on the clipboard to paste.
        if (Clipboard.ContainsText())
            cxmItemPaste.IsEnabled = true;
        else
            cxmItemPaste.IsEnabled = false;
    }
    public void cxmItemContains(object sender, RoutedEventArgs e) { //do your stuff}
    public void cxmItemNotContains(object sender, RoutedEventArgs e) { //do your stuff}
