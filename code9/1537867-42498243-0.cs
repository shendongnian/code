    private async Task GetFileAsync(Identity identity, string serviceAddress, Stream stream)
    {
        var windowsIdentity = Identity as WindowsIdentity;
        if (windowsIdentity == null)
        {
            throw new InvalidOperationException("Identity not a valid windows identity.");
        }
		using (windowsIdentity.Impersonate())
        {
            using (var client = new WebClient { UseDefaultCredentials = true })
            {
                var fileData = await client.DownloadDataTaskAsync(serviceAddress);
                await stream.WriteAsync(fileData, 0, fileData.Length);
                stream.Seek(0, SeekOrigin.Begin);
            }
        }
    }
