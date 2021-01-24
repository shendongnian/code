    private async Task<BitmapImage> CreatePreviewAsync( TimeSpan atTime, int width, int height )
    {        
        var thumbnail = await mediaComposition.GetThumbnailAsync(atTime, width, height, 
                               VideoFramePrecision.NearestKeyFrame);
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.SetSource(thumbnail);
        PreviewImage.Source = bitmapImage;
    }
