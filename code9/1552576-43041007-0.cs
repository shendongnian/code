    var picker = new Windows.Storage.Pickers.FileOpenPicker();
        picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
        picker.SuggestedStartLocation =
        Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
        picker.FileTypeFilter.Add(".jpg");
        picker.FileTypeFilter.Add(".jpeg");
        picker.FileTypeFilter.Add(".png");
    Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
               
            }
            else
            {
               //do some stuff
            }
 
 
  
