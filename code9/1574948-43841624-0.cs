    public async Task<List<Thumbnail>> GetAllThumbnailsAsync()
    {
        var imageUris = await GetAllDirectoriesWithImageAsync(CommandBaseUri)
            .ConfigureAwait(false);
    
        var thumbnailTasks = imageUris.Select(GetThumbnailAsync).ToList();
        var thumbnails = await Task.WhenAll(thumbnailTasks).ConfigureAwait(false);
    
        // I'm assuming there will be sufficiently few thumbnails here
        // that sorting them on the UI thread wouldn't be a problem, in
        // the unlikely event that we're *really* still on the UI thread by
        // this point...
        return thumbnails.OrderByDescending(t => t.ImageDateTime).ToList();           
    }
