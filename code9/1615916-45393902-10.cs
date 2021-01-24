    private async Task<ImageSource> ProcessImageAsync(
        StorageFile file, int width, int height)
    {
        using (var fileStream = await file.OpenReadAsync())
        {
            var transform = new BitmapTransform
            {
                ScaledWidth = (uint)width,
                ScaledHeight = (uint)height,
                InterpolationMode = BitmapInterpolationMode.Cubic
            };
            var decoder = await BitmapDecoder.CreateAsync(fileStream);
            var pixelData = await decoder.GetPixelDataAsync(
                BitmapPixelFormat.Bgra8,
                BitmapAlphaMode.Straight,
                transform,
                ExifOrientationMode.RespectExifOrientation,
                ColorManagementMode.ColorManageToSRgb);
            var pixels = pixelData.DetachPixelData();
            using (var memoryStream = new InMemoryRandomAccessStream())
            {
                var encoder = await BitmapEncoder.CreateAsync(
                    BitmapEncoder.PngEncoderId, memoryStream);
                encoder.SetPixelData(
                    BitmapPixelFormat.Rgba8, BitmapAlphaMode.Ignore,
                    (uint)width, (uint)height, 96, 96, pixels);
                await encoder.FlushAsync();
                memoryStream.Seek(0);
                var bitmap = new WriteableBitmap(width, height);
                await bitmap.SetSourceAsync(memoryStream);
                return await ConvertToGrayAsync(bitmap);
            }
        }
    }
