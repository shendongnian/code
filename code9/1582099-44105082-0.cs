    private async void btnUploadFile_Click(object sender, RoutedEventArgs e)
    {
        var picker = new Windows.Storage.Pickers.FileOpenPicker();
        picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
        picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
        picker.FileTypeFilter.Add(".txt");
        Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
        if (file != null)
        {
            var fileHelper = new DatabaseHelper();
            await fileHelper.UploadFile(file);
        }
    }
