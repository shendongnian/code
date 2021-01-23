     private async void btnConvert_Click(object sender, RoutedEventArgs e)
     {
         StorageFolder localfolder = ApplicationData.Current.LocalFolder;
         StorageFile image1 = await localfolder.GetFileAsync("caffe1.jpg");
         StorageFile image2 = await localfolder.GetFileAsync("caffe2.jpg");
         StorageFile image3 = await localfolder.GetFileAsync("caffe3.jpg");
         StorageFile targettiff = await localfolder.CreateFileAsync("temp.tiff", CreationCollisionOption.ReplaceExisting);
         WriteableBitmap writeableimage1;
         WriteableBitmap writeableimage2;
         WriteableBitmap writeableimage3;
         using (IRandomAccessStream stream = await image1.OpenAsync(FileAccessMode.Read))
         {
             SoftwareBitmap softwareBitmap;
             BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
             softwareBitmap = await decoder.GetSoftwareBitmapAsync();
             writeableimage1 = new WriteableBitmap(softwareBitmap.PixelWidth, softwareBitmap.PixelHeight);
             writeableimage1.SetSource(stream);
         }
         using (IRandomAccessStream stream = await image2.OpenAsync(FileAccessMode.Read))
         {
             SoftwareBitmap softwareBitmap;
             BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
             softwareBitmap = await decoder.GetSoftwareBitmapAsync();
             writeableimage2 = new WriteableBitmap(softwareBitmap.PixelWidth, softwareBitmap.PixelHeight);
             writeableimage2.SetSource(stream);
         }
         using (IRandomAccessStream stream = await image3.OpenAsync(FileAccessMode.Read))
         {
             SoftwareBitmap softwareBitmap;
             BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
             softwareBitmap = await decoder.GetSoftwareBitmapAsync();
             writeableimage3 = new WriteableBitmap(softwareBitmap.PixelWidth, softwareBitmap.PixelHeight);
             writeableimage3.SetSource(stream);
         }
         using (IRandomAccessStream ras = await targettiff.OpenAsync(FileAccessMode.ReadWrite, StorageOpenOptions.None))
         {
             BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.TiffEncoderId, ras);
             var stream = writeableimage1.PixelBuffer.AsStream();
             byte[] buffer = new byte[stream.Length];
             await stream.ReadAsync(buffer, 0, buffer.Length);
             var stream2 = writeableimage2.PixelBuffer.AsStream();
             byte[] buffer2 = new byte[stream2.Length];
             await stream2.ReadAsync(buffer2, 0, buffer2.Length);
             var stream3 = writeableimage3.PixelBuffer.AsStream();
             byte[] buffer3 = new byte[stream3.Length];
             await stream3.ReadAsync(buffer3, 0, buffer3.Length);
             encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)writeableimage1.PixelWidth, (uint)writeableimage1.PixelHeight, 96.0, 96.0, buffer);
             await encoder.GoToNextFrameAsync();
             encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)writeableimage2.PixelWidth, (uint)writeableimage2.PixelHeight, 96.0, 96.0, buffer2);
             await encoder.GoToNextFrameAsync();
             encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)writeableimage3.PixelWidth, (uint)writeableimage3.PixelHeight, 96.0, 96.0, buffer3);
             await encoder.FlushAsync();
         }
     }
