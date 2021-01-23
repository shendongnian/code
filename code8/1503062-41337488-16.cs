    public static async Task SaveDownloadedImage(DownloadedImageModel downloadedImage)
    {
        var databaseConnection = await GetDatabaseConnectionAsync();
        await databaseConnection.InsertOrReplaceAsync(downloadedImage);
    }
