    public async Task<BitmapFrame> GetBitmapFrame(Uri uri)
    {
        var httpClient = new System.Net.Http.HttpClient();
        var buffer = await httpClient.GetByteArrayAsync(uri);
        return await Task.Run(() =>
        {
            using (var stream = new MemoryStream(buffer))
            {
                return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        });
    }
