    private async Task<ImageSource> ProcessImageAsync(StorageFile file)
    {
        using (var stream = await file.OpenReadAsync())
        {
            var dec = await BitmapDecoder.CreateAsync(stream);
            var bitmap = new WriteableBitmap((int)dec.PixelWidth, (int)dec.PixelHeight);
            await bitmap.SetSourceAsync(stream);
            return await ConvertToGrayAsync(bitmap);
        }
    }
