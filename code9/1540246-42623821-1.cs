    public async Task<StorageFile> getFileAsync()
    {
        var picker = new Windows.Storage.Pickers.FileOpenPicker
        {
            ViewMode = Windows.Storage.Pickers.PickerViewMode.List,
            SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary
        };
        picker.FileTypeFilter.Add("*");
    
        var file = await picker.PickSingleFileAsync();
    
        if (file != null)
        {
            return file;
        }
    
        return null;
    }
