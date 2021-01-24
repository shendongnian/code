    private static async Task<Database> Open(String id)
    {
        try
        {
            StorageFile file = await ApplicationData.Current.RoamingFolder.GetFileAsync(id + ".json");
            return new Database(JsonObject.Parse(await FileIO.ReadTextAsync(file)));
        }
        catch (Exception)
        {
            return null;
        }
    }
