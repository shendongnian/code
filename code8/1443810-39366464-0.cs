    public static async Task<MemoryStream> DownloadInstallerAsync(string version)
    {
        string sas = await GetInstallerDownloadLinkAsync(version);
        CloudBlockBlob blob = new CloudBlockBlob(new Uri(sas));
        MemoryStream msRead = new MemoryStream();
        await Task.Run( () => blob.DownloadToStream(msRead) );
        return msRead;
    }
