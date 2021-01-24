    private async void btncreate_Click(object sender, RoutedEventArgs e)
    {
        FileOpenPicker openpicker = new FileOpenPicker();
        openpicker.FileTypeFilter.Add(".jpg");
        openpicker.FileTypeFilter.Add(".png");
        StorageFile originalimage = await openpicker.PickSingleFileAsync();
        WriteableBitmap writeableimage1;
        using (IRandomAccessStream stream = await originalimage.OpenAsync(FileAccessMode.Read))
        {
            SoftwareBitmap softwareBitmap;
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            softwareBitmap = await decoder.GetSoftwareBitmapAsync();
            writeableimage1 = new WriteableBitmap(softwareBitmap.PixelWidth, softwareBitmap.PixelHeight);
            writeableimage1.SetSource(stream);
        }
        StorageFolder folder = ApplicationData.Current.LocalFolder;
        StorageFile newimage = await folder.CreateFileAsync(originalimage.Name, CreationCollisionOption.ReplaceExisting);
        using (IRandomAccessStream ras = await newimage.OpenAsync(FileAccessMode.ReadWrite))
        {
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, ras);
            var stream = writeableimage1.PixelBuffer.AsStream();
            byte[] buffer = new byte[stream.Length];
            await stream.ReadAsync(buffer, 0, buffer.Length);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)writeableimage1.PixelWidth, (uint)writeableimage1.PixelHeight, 96.0, 96.0, buffer);
            await encoder.FlushAsync();
        }
    }
