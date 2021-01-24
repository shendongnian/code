    private void hide_native_click(object sender, RoutedEventArgs e)
    {
        MyPopup.IsOpen = false;
    }
    private void hide_storyboard_click(object sender, RoutedEventArgs e)
    {
        HidePopup.Begin();
    }
    private void show_native_click(object sender, RoutedEventArgs e)
    {
        MyPopup.IsOpen = true;
    }
    private void show_storyboard_click(object sender, RoutedEventArgs e)
    {
        ShowPopup.Begin();
    }
 
