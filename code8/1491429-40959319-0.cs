    public static async Task DownloadAsync(string requestUri, string filename)
    {
        using (var httpClient = new HttpClient())
        {
            using (var fs = File.OpenWrite(filename))
            {
                await (await httpClient.GetStreamAsync(requestUri)).CopyToAsync(fs);
            }
        }
    }
