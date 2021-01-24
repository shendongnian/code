    FileOpenPicker openPicker = new FileOpenPicker();
    openPicker.ViewMode = PickerViewMode.Thumbnail;
    openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
    
    foreach (string extension in FileExtensions.Video)
    {
        openPicker.FileTypeFilter.Add(extension);
    }
    
    file = await openPicker.PickSingleFileAsync();
    if (file != null)
    {
        StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
    	
    	string folderName = System.IO.Path.GetFileNameWithoutExtension(file.Name);	//folder name with filename
    	
        ////await ApplicationData.Current.LocalFolder.CreateFolderAsync("Data");//need to change the folder name with filename
        StorageFolder testFolder = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFolderAsync("test", CreationCollisionOption.OpenIfExists);
    	////StorageFolder newFolder = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
        StorageFolder newFolder = await testFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
    	
        string desiredName = file.Name;
        //should copy it to subfolder and raise alert if already exist
    	
        ////StorageFile newFile = await localFolder.CreateFileAsync(desiredName, CreationCollisionOption.FailIfExists);
    	
    	try
        {
            await file.CopyAsync(newFolder, desiredName, NameCollisionOption.FailIfExists);
        }
        catch(Exception exp)
        {
            //show here messagebox that is exists
            Windows.UI.Xaml.Controls.ContentDialog replacePromptDialog = new Windows.UI.Xaml.Controls.ContentDialog()
            {
                Title = "File exists in the new location",
                Content = "Do you want to replace the old file with the new file?",
                CloseButtonText = "Keep the old one",
                PrimaryButtonText = "Replace with new one"
            };
            Windows.UI.Xaml.Controls.ContentDialogResult result = await replacePromptDialog.ShowAsync();
            if (result == Windows.UI.Xaml.Controls.ContentDialogResult.Primary)
            {
                await file.CopyAsync(newFolder, desiredName, NameCollisionOption.ReplaceExisting);
            }
        }
    
    }
