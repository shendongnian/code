    public async Task SomeMethod() {
        // Determine which files to download
        List<FileRequest> fileRequests = Determine();
        //this will allow the down load to not lock the ui
        await DownloadFilesAsync(fileRequests);
        // After that do something else with downloaded files synchronously
        //...
    }
    public async Task DownloadFilesAsync(List<FileRequest> fileRequests) {
        await Task.WhenAll(fileRequests.Select(fileRequest =>
            DownloadFileAsync(fileRequest))).ConfigureAwait(false);
    }
    public async Task DownloadFileAsync(FileRequest fileRequest) {
        using (WebClient client = new WebClient()) {
            await client.DownloadFileTaskAsync(fileRequest.url,fileRequest.downloadPath).ConfigureAwait(false);
        }
    }
