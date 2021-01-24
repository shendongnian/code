    // The caller of this method may use ConfigureAwait(false) as well,
    // depending on the call-site and result-usage.
    public async Task<String> GetDBPathAndCreateIfNotExists()
    {
        String filename = "birdsnbflys.db3";
        // Check if file exists
        var file = await ApplicationData.Current.LocalFolder.TryGetItemAsync(filename).ConfigureAwait(false);
        var fileExists = file != null;
        // If the file doesn't exist, copy it without blocking the task
        if (!fileExists)
        {
            var databaseFile = await Package.Current.InstalledLocation
                .GetFileAsync(filename)
                .ConfigureAwait(false);
            await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder,
                                         filename,
                                         NameCollisionOption.ReplaceExisting)
                              .ConfigureAwait(false);
        }
        return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
    }
