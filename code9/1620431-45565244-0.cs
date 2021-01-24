    CanvasDevice device = CanvasDevice.GetSharedDevice();
    CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, 300, 300, 96);
    using (var ds = renderTarget.CreateDrawingSession())
    {
        ds.Clear(Colors.White);           
        ds.DrawRectangle(155, 115, 80, 30, Colors.Black);
    } 
    CanvasBitmap bit = renderTarget;
    string filename = "Test pic test.png";
    StorageFolder pictureFolder = KnownFolders.SavedPictures;
    var file = await pictureFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
    using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
    {
        await bit.SaveAsync(fileStream, CanvasBitmapFileFormat.Png, 1f);
    }
