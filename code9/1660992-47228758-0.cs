    public async Task CreatePictureFolderAsync()
    {
        try
        {
            var folder = await DownloadsFolder.CreateFolderAsync("Pictures");
            // add your folder to StorageApplicationPermissions.FutureAccessList
            StorageApplicationPermissions.FutureAccessList.AddOrReplace(token, folder);
        }
        catch (Exception ex) { ex.Exception("CreatePictureFolderAsync"); }
    }
