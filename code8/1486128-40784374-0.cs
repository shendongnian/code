    if (inkCanvas.InkPresenter.StrokeContainer.GetStrokes().Count > 0)
    {
        var savePicker = new Windows.Storage.Pickers.FileSavePicker();
        savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
        savePicker.FileTypeChoices.Add("Gif,JPG,PNG", new System.Collections.Generic.List<string> { ".jpg", ".gif", ".png" });
        Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
        if (null != file)
        {
            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await inkCanvas.InkPresenter.StrokeContainer.SaveAsync(stream);
            }
            using (IRandomAccessStream streamforread = await file.OpenAsync(FileAccessMode.Read))
            {
                WriteableBitmap inkimagesource = new WriteableBitmap(50, 50);
                inkimagesource.SetSource(streamforread);
                byte[] imageBuffer = inkimagesource.PixelBuffer.ToArray();
                MemoryStream ms = new MemoryStream(imageBuffer);
            }
        }
    }
