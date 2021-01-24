    private async Task<ImageSource> ProcessImageAsync(
        StorageFile file, int width, int height)
    {
        BitmapDecoder decoder;
        using (var fileStream = await file.OpenReadAsync())
        {
            decoder = await BitmapDecoder.CreateAsync(fileStream);
        }
        var transform = new BitmapTransform
        {
            ScaledWidth = (uint)width,
            ScaledHeight = (uint)height,
            InterpolationMode = BitmapInterpolationMode.Cubic
        };
        var pixelData = await decoder.GetPixelDataAsync(
            BitmapPixelFormat.Bgra8,
            BitmapAlphaMode.Straight,
            transform,
            ExifOrientationMode.RespectExifOrientation,
            ColorManagementMode.ColorManageToSRgb);
        var pixels = pixelData.DetachPixelData();
        var bitmap = new WriteableBitmap(width, height);
        using (var memoryStream = new InMemoryRandomAccessStream())
        {
            var encoder = await BitmapEncoder.CreateAsync(
                BitmapEncoder.PngEncoderId, memoryStream);
            encoder.SetPixelData(
                BitmapPixelFormat.Rgba8, BitmapAlphaMode.Straight,
                (uint)width, (uint)height, 96, 96, pixels);
            await encoder.FlushAsync();
            memoryStream.Seek(0);
            await bitmap.SetSourceAsync(memoryStream);
        }
        return await ConvertToGrayAsync(bitmap);
    }
