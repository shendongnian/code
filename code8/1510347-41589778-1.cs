    private async Task<string> Upload(DropboxClient dbx, string localPath, string remotePath)
        {
            const int ChunkSize = 4096 * 1024;
            using (var fileStream = File.Open(localPath, FileMode.Open))
            {
                if (fileStream.Length <= ChunkSize)
                {
                    WriteMode mode = new WriteMode();
                    FileMetadata fileMetadata = await dbx.Files.UploadAsync(remotePath, body: fileStream, mode: mode.AsAdd, autorename: true);
                    //set the expiry date
                    var existingDoc = await dbx.Files.GetMetadataAsync(remotePath);
                    if (existingDoc.IsFile)
                    {
                        var sharedLink = await dbx.Sharing.ListSharedLinksAsync(remotePath);
                        var settings = new ListSharedLinksArg(remotePath);
                        ListSharedLinksResult listSharedLinksResult = await dbx.Sharing.ListSharedLinksAsync(remotePath);
                        if (listSharedLinksResult.Links.Count > 0)
                        {
                            return listSharedLinksResult.Links[0].Url;
                        }
                        else
                        {
                            var sharedLinkSettings = new SharedLinkSettings(expires: DateTime.Today.AddDays(7));
                            SharedLinkMetadata sharedLinkMetadata = await dbx.Sharing.CreateSharedLinkWithSettingsAsync(remotePath, sharedLinkSettings);
                            return sharedLinkMetadata.Url;
                        }
                    }
                    else
                    {
                        var settings = new SharedLinkSettings(expires: DateTime.Today.AddDays(7));
                        SharedLinkMetadata sharedLinkMetadata = await dbx.Sharing.CreateSharedLinkWithSettingsAsync(fileMetadata.PathLower, settings);
                        return sharedLinkMetadata.Url;
                    }
                }
                else
                {
                    var sharedLink = await this.ChunkUpload(dbx, remotePath, fileStream, ChunkSize);
                    return sharedLink;
                }
            }
