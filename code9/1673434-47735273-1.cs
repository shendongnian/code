    public async Task SetImage(string title, string tags, Uri uri)
    {
        var image = new GalleryImage
        {
            Title = title,
            Tags = ParseTags(tags),
            Url = uri.AbsoluteUri,
            Created = DateTime.Now
        };
        _ctx.Add(image);
        await _ctx.SaveChangesAsync();
    }
