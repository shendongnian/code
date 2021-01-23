    private void Header_P(object sender, TappedRoutedEventArgs e)
    {
        var colorBrush = chkColor.Fill as SolidColorBrush;
        if (colorBrush != null)
        {
            colorimg.Foreground = new SolidColorBrush(colorBrush.Color);
        }
    }
