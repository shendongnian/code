    var fileSavePicker = new Windows.Storage.Pickers.FileSavePicker();
    fileSavePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
    var filedb = new[] { ".db" };
    fileSavePicker.FileTypeChoices.Add("DB", filedb);
    fileSavePicker.SuggestedFileName = "BACKUPDB" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year;
    //var pathDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "file.db");
    try
    {
        StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("file.db");
        StorageFile localfile = await fileSavePicker.PickSaveFileAsync();
        if (file != null)
        {
            Debug.WriteLine("file Exists!!");
            await file.CopyAndReplaceAsync(localfile);
        }
    }
    catch(Exception ex)
    {
        Debug.WriteLine(ex);
    }
