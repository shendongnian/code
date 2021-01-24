    private async void button_Click(object sender, RoutedEventArgs e)
    {
        RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
         await renderTargetBitmap.RenderAsync(ImageHolder);
         var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();
         var pixels = pixelBuffer.ToArray();
         var displayInformation = DisplayInformation.GetForCurrentView();
         var picker = new FileSavePicker();
         picker.FileTypeChoices.Add("PNG Image", new string[] { ".png" });
         StorageFile file = await picker.PickSaveFileAsync();             
         using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
         {
             var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
             encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, (uint)renderTargetBitmap.PixelWidth, (uint)renderTargetBitmap.PixelHeight, displayInformation.RawDpiX, displayInformation.RawDpiY, pixels);
             await encoder.FlushAsync();
         }
    }
