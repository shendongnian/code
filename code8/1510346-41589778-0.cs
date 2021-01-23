    private async Task<string> Upload(DropboxClient dbx, string localPath, string remotePath)
    {
    //rest of code
    var existingDoc = await dbx.Files.GetMetadataAsync(remotePath);
        if (existingDoc.IsFile)
           {
           var sharedLink = dbx.Sharing.ListSharedLinksAsync(remotePath);
           var settings = new ListSharedLinksArg(remotePath);
                        ListSharedLinksResult listSharedLinksResult = await dbx.Sharing.ListSharedLinksAsync(settings);
           if (listSharedLinksResult.Links.Count > 0)
              {
                  return listSharedLinksResult.Links[0].Url;
              }
            else
              {
                  var link = getSharedLink(dbx, fileMetadata);
                  return link.Result;
              }
           }
           else
              {
                  var link = getSharedLink(dbx, fileMetadata);
                  return link.Result;
              }
          }
    }
    private async Task<string> getSharedLink(DropboxClient dbx, FileMetadata fileMetadata)
    {
        var settings = new SharedLinkSettings(expires: DateTime.Today.AddDays(7));
        SharedLinkMetadata sharedLinkMetadata = await dbx.Sharing.CreateSharedLinkWithSettingsAsync(fileMetadata.PathLower, settings);
        return sharedLinkMetadata.Url;
    }
