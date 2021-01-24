    // ItemId is the item's identifier on ArcGIS Online
    private async Task GetData(string itemId)
    {
        // Create the portal
        var portal = await ArcGISPortal.CreateAsync().ConfigureAwait(false);
        // Create the portal item
        var item = await PortalItem.CreateAsync(portal, itemId).ConfigureAwait(false);
        // Create the SampleData folder
        var tempFile = Path.Combine(GetDataFolder(), "Data");
        createDir(new DirectoryInfo(tempFile));
        // Get the full path to the specific file
        tempFile = Path.Combine(tempFile, item.Name);
        // Download the file
        using (var s = await item.GetDataAsync().ConfigureAwait(false))
        {
            using (var f = File.Create(tempFile))
            {
                await s.CopyToAsync(f).ConfigureAwait(false);
            }
        }
    }
