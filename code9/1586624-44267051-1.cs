    private Image buttonDownImage;
    private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        buttonDownImage = e.OriginalSource as Image;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (buttonDownImage != null)
        {
            //The click source the buttonDownImage
        }
    }
