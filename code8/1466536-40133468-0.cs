    /// <summary>
    /// Picks a folder.
    /// </summary>
    public async void PickFolder() {
        var folderPicker = new Windows.Storage.Pickers.FolderPicker();
        folderPicker.SuggestedStartLocation = 
            Windows.Storage.Pickers.PickerLocationId.Desktop;
        // unless you want to open a folder, FileTypeFilter is required
        folderPicker.FileTypeFilter.Add(".cs");
        folderPicker.FileTypeFilter.Add(".jpg");
        Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
        if (folder != null) {
            // Application now has read/write access to all contents in the picked folder
            // (including other sub-folder contents)
            Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", folder);
            StorageFolder mainFolder = await folder.CreateFolderAsync("Generator");
            await mainFolder.CreateFolderAsync("Code");
            await mainFolder.CreateFolderAsync("EventsArgs");
            StorageFolder newFolder = 
                      await CreateFileInANewFolder(mainFolder, "MyFolder", "MyCode.cs",
                          new List<string>() { "My code line 1", "My code line 2" });
            List<string> fileLines = await ReadFile(newFolder, "MyCode.cs");
            StorageFile file = 
                await mainFolder.CreateFileAsync("Code.cs", 
                                                 CreationCollisionOption.ReplaceExisting);
            List<string> lines = new List<string>() { 
                     "Hello world!", "This is a second line" 
            };
            await FileIO.WriteLinesAsync(file, lines);
        }
        else {
            // the user didn't select any folder
        }
    }
