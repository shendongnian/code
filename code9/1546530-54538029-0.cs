            var folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Downloads;
            folderPicker.FileTypeFilter.Add("*");
            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("DownloadFolderToken", folder);
                var messageDialog = new MessageDialog("Download folder: " + folder.Name);
                await messageDialog.ShowAsync();
            }
            else
            {
                var messageDialog = new MessageDialog("Operation cancelled");
                await messageDialog.ShowAsync();
            }
