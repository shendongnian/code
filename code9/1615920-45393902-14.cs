    private async Task<WriteableBitmap> ConvertToGrayAsync(WriteableBitmap srcBitmap)
    {
        var pixels = srcBitmap.PixelBuffer.ToArray();
        for (int i = 0; i < pixels.Length; i += 4)
        {
            var b = pixels[i];
            var g = pixels[i + 1];
            var r = pixels[i + 2];
            var f = (byte)(0.21 * r + 0.71 * g + 0.07 * b);
            pixels[i] = f;
            pixels[i + 1] = f;
            pixels[i + 2] = f;
        }
        var dstBitmap = new WriteableBitmap(srcBitmap.PixelWidth, srcBitmap.PixelHeight);
        using (var pixelStream = dstBitmap.PixelBuffer.AsStream())
        {
            await pixelStream.WriteAsync(pixels, 0, pixels.Length);
        }
        return dstBitmap;
    }
