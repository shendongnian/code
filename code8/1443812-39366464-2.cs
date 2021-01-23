    public static async Task<MemoryStream> DownloadInstallerAsync(string version)
    {
        string sas = await GetInstallerDownloadLinkAsync(version);
        CloudBlockBlob blob = new CloudBlockBlob(new Uri(sas));
        MemoryStream msRead = new MemoryStream();
        await blob.DownloadToStreamAsync(msRead);
        return msRead;
    }
