    var picker = new Windows.Storage.Pickers.FolderPicker();
    picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
    picker.FileTypeFilter.Add("*");
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
    var folder = await picker.PickSingleFolderAsync();
    if(folder != null)
    {
        StringBuilder outputText =  new StringBuilder();
        var query = folder.CreateFileQuery();
        var files = await query.GetFilesAsync();
        foreach (StorageFile file in files)
        {
            outputText.Append(file.Name + "\n");
        }
    }
