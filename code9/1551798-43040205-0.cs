    private byte[] managedArray;
    
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Windows.Storage.Streams.IRandomAccessStream random = await Windows.Storage.Streams.RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/sunset.jpg")).OpenReadAsync();
        Windows.Graphics.Imaging.BitmapDecoder decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(random);
        Windows.Graphics.Imaging.PixelDataProvider pixelData = await decoder.GetPixelDataAsync();
        byte[] buffer = pixelData.DetachPixelData();
        unsafe
        {
            fixed (byte* p = buffer)
            {
                IntPtr ptr = (IntPtr)p;
                managedArray = new byte[buffer.Length];
                Marshal.Copy(ptr, managedArray, 0, buffer.Length);
            }
        }
        WriteableBitmap bitmap = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
        await bitmap.PixelBuffer.AsStream().WriteAsync(managedArray, 0, managedArray.Length);
        InMemoryRandomAccessStream inMemoryRandomAccessStream = new InMemoryRandomAccessStream();
        BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, inMemoryRandomAccessStream);
        Stream pixelStream = bitmap.PixelBuffer.AsStream();
        byte[] pixels = new byte[pixelStream.Length];
        await pixelStream.ReadAsync(pixels, 0, pixels.Length);
        encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight, 96.0, 96.0, pixels);
        await encoder.FlushAsync();
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.SetSource(inMemoryRandomAccessStream);
        MyImage.Source = bitmapImage;
    }
