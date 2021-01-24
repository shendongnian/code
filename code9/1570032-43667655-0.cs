    try {
        var account = await this.client.Users.GetCurrentAccountAsync();
        // use account
    } catch (DropboxException ex) {
        // inspect and handle ex as desired
    }
    try {
        var list = await client.Files.ListFolderAsync(string.Empty);
        // use list
    } catch (DropboxException ex) {
        // inspect and handle ex as desired
    }
    try {
        var download = await client.Files.DownloadAsync(path);
        // use download
    } catch (DropboxException ex) {
        // inspect and handle ex as desired
    }
