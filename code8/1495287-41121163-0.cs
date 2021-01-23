    public static async Task<bool> checkDataBaseConnection()
    {
        if (null == await ApplicationData.Current.LocalFolder.TryGetItemAsync("sale.db"))
        {
            StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync("sale.db");
            await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder, "sale.db", NameCollisionOption.ReplaceExisting);
        }
    
        return true;
    }
