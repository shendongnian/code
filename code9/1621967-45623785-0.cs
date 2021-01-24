    public async Task<Image> DownloadJPGAsync()
    {
        string picloc = "[redacted]";
        Stream imgstream = await client.GetStreamAsync(picloc).ConfigureAwait(false);
        Bitmap blah2 = new Bitmap(imgstream);
        return blah2;
    }
