    private async Task setupdatabase()
    {
        StorageFolder sfolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Data");
        await CopyFolderAsync(sfolder, ApplicationData.Current.LocalCacheFolder);
    }
    public static async Task CopyFolderAsync(StorageFolder source, StorageFolder destinationContainer, string desiredName = null)
    {
        StorageFolder destinationFolder = await destinationContainer.CreateFolderAsync(desiredName ?? source.Name, CreationCollisionOption.OpenIfExists);
        var existingItems = await destinationFolder.GetFilesAsync(); // to check if files are already there
        foreach (var file in (await source.GetFilesAsync()).Where(x => !existingItems.Any(y => y.Name == x.Name)))
        {
            await file.CopyAsync(destinationFolder, file.Name);
        }
        foreach (var folder in await source.GetFoldersAsync())
        {
            await CopyFolderAsync(folder, destinationFolder);
        }
    }
