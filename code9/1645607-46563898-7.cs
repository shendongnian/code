    private void OpenList_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        FocusManager.SetFocusedElement(cb1, cb1);
        cb1.IsDropDownOpen = true;
    }
    private void ToggleHot_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        hotToggle.IsChecked = !hotToggle.IsChecked;
    }
    private void ToggleMilk_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        milkToggle.IsChecked = !milkToggle.IsChecked;
    }
    private void ToggleLemon_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        lemonToggle.IsChecked = !lemonToggle.IsChecked;
    }
    private void ToggleSyrup_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        syrupToggle.IsChecked = !syrupToggle.IsChecked;
    }
