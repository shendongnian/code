    private async void btnSaveImage_Click(object sender, RoutedEventArgs e)
    {
        RenderTargetBitmap bitmap = new RenderTargetBitmap();
        await bitmap.RenderAsync(MyCreatedImage);
        var pixelBuffer = await bitmap.GetPixelsAsync();
        var pixels = pixelBuffer.ToArray();
        var displayInformation = DisplayInformation.GetForCurrentView();
        StorageFolder pictureFolder = KnownFolders.SavedPictures;
        var file = await pictureFolder.CreateFileAsync("test2.jpg", CreationCollisionOption.ReplaceExisting);
        using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
        {
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                 BitmapAlphaMode.Premultiplied,
                                 (uint)bitmap.PixelWidth,
                                 (uint)bitmap.PixelHeight,
                                 displayInformation.RawDpiX,
                                 displayInformation.RawDpiY,
                                 pixels);
            await encoder.FlushAsync();
        }
    }
