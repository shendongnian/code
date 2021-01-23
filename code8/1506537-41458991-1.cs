    private void TTLStap(object sender, TappedRoutedEventArgs e)
    {
        pSong.Source = new Uri("ms-appx:///Videos/twinkle.mp4");
        pSong.AreTransportControlsEnabled = true; 
        //show the media element
        pSong.Visibility = Visibility.Visible;
    }
