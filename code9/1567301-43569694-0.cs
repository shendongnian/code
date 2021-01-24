    async Task Download(DropboxClient dbx, string folder, string file)
    {
        using (var response = await dbx.Files.DownloadAsync(folder + "/" + file))
        {
            return response.GetContentAsByteArrayAsync();
        }
    }
