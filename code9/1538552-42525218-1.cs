    private async Task<ImageSource> FromBase64(byte[] bytes)
    {
        
        var image = bytes.AsBuffer().AsStream().AsRandomAccessStream();
    
        // decode image
        var decoder = await BitmapDecoder.CreateAsync(image);
        image.Seek(0);
    
        // create bitmap
        var output = new WriteableBitmap((int)decoder.PixelHeight, (int)decoder.PixelWidth);
        await output.SetSourceAsync(image);
        return output;
    }
