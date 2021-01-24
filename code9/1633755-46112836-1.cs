    private async void VideoPlayer_Loaded(object sender, RoutedEventArgs e)
    {
        var videoFile = await Package.Current.InstalledLocation.GetFileAsync("big_buck_bunny.mp4");  
        MediaClip clip = await MediaClip.CreateFromFileAsync(videoFile);
    
        var videoEffectDefinition = new VideoEffectDefinition(typeof(RExampleVidoEffect).FullName);
        clip.VideoEffectDefinitions.Add(videoEffectDefinition);
    
        MediaComposition compositor = new MediaComposition();
        compositor.Clips.Add(clip);
    
        this.VideoPlayer.SetMediaStreamSource(compositor.GenerateMediaStreamSource());
    
    }
    
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var bitmap = RExampleVidoEffect.GetSnapShot();
    
        if (bitmap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 ||
             bitmap.BitmapAlphaMode == BitmapAlphaMode.Straight)
        {
            bitmap = SoftwareBitmap.Convert(bitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
        }
        var source = new SoftwareBitmapSource();
        await source.SetBitmapAsync(bitmap);
        img.Source = source;
    }
