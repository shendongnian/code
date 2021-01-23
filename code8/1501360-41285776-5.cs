    private async Task PickFilesCommandHandler()
    {
         var file = await CrossFilePicker.Current.PickFile();
         var fileEntity = new FileEntity
         {
             FileName = file.FileName,
             DataArray = file.DataArray
         };
    }
