    public static async Task SaveDownloadedImage(DownloadedImageModel downloadedImage)
    {
        var databaseConnection = await GetDatabaseConnectionAsync();
        if (await GetDownloadedImageAsync(downloadedImage.ImageUrl) != null)
            await databaseConnection.UpdateAsync(downloadedImage);
        else
            await databaseConnection.InsertAsync(downloadedImage);
    }
