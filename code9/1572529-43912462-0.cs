    if (localfile != null)
    {
        var localprop = await localfile.GetBasicPropertiesAsync();
        var localtime = localprop.DateModified;               
        try
        {
            Stream syncstream = await localfile.OpenStreamForReadAsync();
            using (syncstream)
            {
                DriveItem upload = await _userDrive.Me.Drive.Root.ItemWithPath("regfolder/regdata.jpg").Content.Request().PutAsync<DriveItem>(syncstream);
                DriveItem updateitem = new DriveItem() {
                      FileSystemInfo=new Microsoft.Graph.FileSystemInfo()
                      {
                          LastModifiedDateTime = localtime
                      }
                };                      
                DriveItem Updated = await _userDrive.Me.Drive.Root.ItemWithPath("regfolder/regdata.jpg").Request().UpdateAsync(updateitem); 
            }
        }
        catch (Exception ex)
        { }
    }
