    private async Task<Boolean> Save()
    {
        try
        {
            updated = DateTime.Now;
            StorageFile file = await ApplicationData.Current.RoamingFolder.CreateFileAsync(id + ".json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, ToJson().Stringify());
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
