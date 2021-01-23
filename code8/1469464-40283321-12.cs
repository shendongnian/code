    private void photo_Tapped(object sender, TappedRoutedEventArgs e)
    {
        var tag = (sender as Image)?.Tag?.ToString();
        //if we didn't set Tag in Image, its value should be null and descBox1 will be Visible 
        if (string.IsNullOrEmpty(tag) || tag.Equals("Visible"))
        {
            (sender as Image).Tag = Visibility.Collapsed;
        }
        else
        {
            (sender as Image).Tag = Visibility.Visible;
        }
    }
