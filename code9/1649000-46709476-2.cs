    public static async Task<BitmapSource> GetNewImageAsync(Uri uri)
    {
        var httpClient = new HttpClient();
        using (var response = await httpClient.GetAsync(uri))
        {
            if (response.IsSuccessStatusCode)
            {
                using (var stream = new MemoryStream())
                {
                    await response.Content.CopyToAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    return BitmapFrame.Create(
                        stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            }
        }
        return null;
    }
