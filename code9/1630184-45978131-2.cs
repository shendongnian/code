     private async void buttonClick(){
                FolderPicker folderPicker = new FolderPicker();
         folderPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
          folderPicker.FileTypeFilter.Add("*");
    
              StorageFolder folder=  await folderPicker.PickSingleFolderAsync();
             if (folder != null) { 
    
                  //  do Things On Folder
    
              }
               else
              {
                  MessageDialog dialog = new MessageDialog("you selected nothing");
                 await dialog.ShowAsync();
              }
    
    }
