    var removableDevices = KnownFolders.RemovableDevices;
    // Get all driver letters
    var folders = await removableDevices.GetFoldersAsync();
    if (folders.Count > 0)
    {
        foreach (StorageFolder folder in folders)
        {
            System.Diagnostics.Debug.WriteLine(folder.Name);
            // Check the driver letter is empty or not.
            var items = folder.GetItemsAsync();
            if (items == null)
            {
                System.Diagnostics.Debug.WriteLine("There are no files and folders.");
            }
        }
    }
