    CloudRail.AppKey = "{Your_License_Key}";
    // Google Drive:
    GoogleDrive drive = new GoogleDrive(this, "[clientIdentifier]", "", "[redirectUri]", "[state]");
    drive.UseAdvancedAuthentication();
    ICloudStorage cs = drive;
    new System.Threading.Thread(new System.Threading.ThreadStart(() =>
    {
        try
        {
            IList<CloudMetaData> filesFolders = cs.GetChildren("/");
            //IList<CloudMetaData> filesFolders = cs.GetChildrenPage("/", 1, 4);  // Path, Offet, Limit
            //cs.Upload(/image_2.jpg,stream,1024,true);   // Path and Filename, Stream (data), Size, overwrite (true/false)
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
     })).Start();
