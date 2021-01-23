    private async void ButtonBase_OnClick(object sender, RoutedEventArgs args)
    {
        var folderPicker = new FolderPicker();
        var folder = await folderPicker.PickSingleFolderAsync();
        if (folder != null)
        {
            ChosenFiles.ItemsSource = await GetFileInfoAsync(folder);
        }
    }
    public async Task<List<string>> GetFileInfoAsync(StorageFolder folder)
    {
        List<string> files = new List<string>();
        var allFiles = await folder.GetFilesAsync();
        foreach (var file in allFiles)
        {
            files.Add(file.Name);
        }
        return files;
    }
