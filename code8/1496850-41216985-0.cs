    var picker = new FileOpenPicker();
    picker.FileTypeFilter.Add(".png");
    picker.FileTypeFilter.Add(".jpg");
    picker.FileTypeFilter.Add(".jpeg");
    var sourceFile = await picker.PickSingleFileAsync();
    if (sourceFile == null) { return; }
    var device = CanvasDevice.GetSharedDevice();
    var image = default(CanvasBitmap);
    using (var s = await sourceFile.OpenReadAsync())
    {
        image = await CanvasBitmap.LoadAsync(device, s);
    }
    var offscreen = new CanvasRenderTarget(
        device, (float)image.Bounds.Width, (float)image.Bounds.Height, 96);
    using (var ds = offscreen.CreateDrawingSession())
    {
        ds.DrawImage(image, 0, 0);
        ds.DrawText("Hello world", 10, 10, Colors.Blue);
    }
    var displayInformation = DisplayInformation.GetForCurrentView();
    var savepicker = new FileSavePicker();
    savepicker.FileTypeChoices.Add("png", new List<string> { ".png" });
    var destFile = await savepicker.PickSaveFileAsync();
    using (var s = await destFile.OpenAsync(FileAccessMode.ReadWrite))
    {
        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, s);
        encoder.SetPixelData(
            BitmapPixelFormat.Bgra8,
            BitmapAlphaMode.Ignore,
            (uint)offscreen.Size.Width,
            (uint)offscreen.Size.Height,
            displayInformation.LogicalDpi,
            displayInformation.LogicalDpi,
            offscreen.GetPixelBytes());
        await encoder.FlushAsync();
    }
