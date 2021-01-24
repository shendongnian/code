    private async void Image_Tapped(object sender, TappedRoutedEventArgs e)
    {
        if (((Image)sender).Source is BitmapImage bitmapImage)
        {
            var uri = bitmapImage.UriSource;
            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }
        }
    }
