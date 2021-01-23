        static class Extension
        {
            public static async Task<IRandomAccessStream>
                RenderToRandomAccessStream(this UIElement element)
            {
                RenderTargetBitmap rtb = new RenderTargetBitmap();
                await rtb.RenderAsync(element);
    
                var pixelBuffer = await rtb.GetPixelsAsync();
                var pixels = pixelBuffer.ToArray();
                var displayInformation = DisplayInformation.GetForCurrentView();
    
                var stream = new InMemoryRandomAccessStream();
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                     BitmapAlphaMode.Premultiplied,
                                     (uint)rtb.PixelWidth,
                                     (uint)rtb.PixelHeight,
                                     displayInformation.RawDpiX,
                                     displayInformation.RawDpiY,
                                     pixels);
    
                await encoder.FlushAsync();
                stream.Seek(0);
    
                return stream;
            }
        }
