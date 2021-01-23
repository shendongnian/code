    private async void btngetfolder_Click(object sender, RoutedEventArgs e)
    {
        var folderPicker = new Windows.Storage.Pickers.FolderPicker();
        folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
        folderPicker.FileTypeFilter.Add("*");
        folderPicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
        Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
        if (folder != null)
        {
            IReadOnlyList<StorageFolder> folderList = await folder.GetFoldersAsync();
            foreach (StorageFolder subfolder in folderList)
            {
                Debug.WriteLine("subfolder path:" + subfolder.Path);
            } 
        }
    }
