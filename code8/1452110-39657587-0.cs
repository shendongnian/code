    private void DarkTheme_OnClick(object sender, RoutedEventArgs e)
    {
        ThemeAwareFrame rootFrame = Window.Current.Content as ThemeAwareFrame;
        rootFrame.AppTheme = ElementTheme.Dark;
     }
