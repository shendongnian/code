    public static async void BackupDBByCopy()
    {
        StorageFolder localfolder = ApplicationData.Current.LocalFolder;        
        StorageFile dboriginal = await localfolder.GetFileAsync("DB.sqlite");         
        await dboriginal.CopyAsync(localfolder, "DBBACKUP.sqlite", NameCollisionOption.ReplaceExisting);
    }
