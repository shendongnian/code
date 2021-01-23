    var picker = new Windows.Storage.Pickers.FileOpenPicker();
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
    picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
    picker.FileTypeFilter.Add(".txt");
    Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
    if (file != null)
    {
        // register provider - by default encoding is not supported
        Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        using (var inputStream = await file.OpenReadAsync())
        using (var classicStream = inputStream.AsStreamForRead())
        using (var streamReader = new StreamReader(classicStream, Encoding.GetEncoding(1250)))
        {
            var something = streamReader.ReadToEnd();
        }
    }
