    private async Task<WriteableBitmap> DecodeWriteableBitmap(
        StorageFile file, int width, int height)
    {
        using (var fileStream = await file.OpenReadAsync())
        using (var memoryStream = new InMemoryRandomAccessStream())
        {
            var decoder = await BitmapDecoder.CreateAsync(fileStream);
            var transform = new BitmapTransform
            {
                ScaledWidth = (uint)width,
                ScaledHeight = (uint)height,
                InterpolationMode = BitmapInterpolationMode.Cubic
            };
            var pixelData = await decoder.GetPixelDataAsync(
                BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, transform,
                ExifOrientationMode.RespectExifOrientation,
                ColorManagementMode.ColorManageToSRgb);
            var pixels = pixelData.DetachPixelData();
            var encoder = await BitmapEncoder.CreateAsync(
                BitmapEncoder.PngEncoderId, memoryStream);
            encoder.SetPixelData(
                BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight,
                (uint)width, (uint)height, 96, 96, pixels);
            await encoder.FlushAsync();
            memoryStream.Seek(0);
            var bitmap = new WriteableBitmap(width, height);
            await bitmap.SetSourceAsync(memoryStream);
            return bitmap;
        }
    }
