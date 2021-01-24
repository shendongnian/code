    Uri imageuri = new Uri("ms-appx:///Assets/HelloMyNameIs.jpg");
    StorageFile inputFile = await StorageFile.GetFileFromApplicationUriAsync(imageuri);
    BitmapDecoder imagedecoder;
    using (var imagestream = await inputFile.OpenAsync(FileAccessMode.Read))
    {
        imagedecoder =await BitmapDecoder.CreateAsync(imagestream);
    }  
    CanvasDevice device = CanvasDevice.GetSharedDevice();
    CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, imagedecoder.PixelWidth, imagedecoder.PixelHeight, 96);
    using (var ds = renderTarget.CreateDrawingSession())
    {
        ds.Clear(Colors.White);
        CanvasBitmap image = await CanvasBitmap.LoadAsync(device, inputFile.Path, 96);
        ds.DrawImage(image);
        ds.DrawText(lblName.Text, new System.Numerics.Vector2(150, 150), Colors.Black);
    }
    string filename = "test1.png";
    StorageFolder pictureFolder = KnownFolders.SavedPictures;
    var file = await pictureFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
    using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
    {
        await renderTarget.SaveAsync(fileStream, CanvasBitmapFileFormat.Png, 1f);
    }
