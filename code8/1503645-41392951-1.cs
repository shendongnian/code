    public async Task<WriteableBitmap> SaveToImageSource(byte[] imageBuffer)
    {             
        using (MemoryStream stream = new MemoryStream(imageBuffer))
        {
            var ras = stream.AsRandomAccessStream();
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(BitmapDecoder.JpegDecoderId, ras);
            var provider = await decoder.GetPixelDataAsync();
            byte[] buffer = provider.DetachPixelData();
            WriteableBitmap ablebitmap = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
            await ablebitmap.PixelBuffer.AsStream().WriteAsync(buffer, 0, buffer.Length);
            return ablebitmap;
        }           
    }
