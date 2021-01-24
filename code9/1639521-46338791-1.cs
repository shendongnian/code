    MediaElement playback = new MediaElement();
    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        
        var file = await Package.Current.InstalledLocation.GetFileAsync("test.mp3");
        if (file != null)
        {
            var stream = await file.OpenReadAsync();
            playback.SetSource(stream, file.ContentType);
        }
        playback.Play();
        root.Children.Add(playback);
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (playback.CanSeek)
        {
            playback.Position = TimeSpan.FromSeconds(5);
        }
    }
