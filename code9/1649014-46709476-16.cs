    public static async Task<BitmapSource> GetNewImageAsync(Uri uri)
    {
        BitmapSource bitmap = null;
        var httpClient = new HttpClient();
        using (var response = await httpClient.GetAsync(uri))
        {
            if (response.IsSuccessStatusCode)
            {
                using (var stream = new MemoryStream())
                {
                    await response.Content.CopyToAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    bitmap = BitmapFrame.Create(
                        stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            }
        }
        return bitmap;
    }
