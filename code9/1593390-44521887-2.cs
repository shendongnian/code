    public async Task<Models.Models.File> DownloadAndZipCarousel(IEnumerable<Image> images, string baseServerPath) {
        var client     = CreateClient();
        var file       = new Models.Models.File();
        var random     = new Random();
    
        using (var archiveStream = new MemoryStream())
        using (var archive       = new ZipArchive(archiveStream, ZipArchiveMode.Create, true)) {
            foreach (Image image in images) {
                ZipArchiveEntry archiveEntry = archive.CreateEntry($"Instagram{random.Next()}.jpg", CompressionLevel.Optimal);
                using (Stream entryStream = archiveEntry.Open())
                using (Stream contentStream = await client.GetStreamAsync(image.StandartResolutionURL)) {
                    await contentStream.CopyToAsync(entryStream);
                    entryStream.Position = 0;
                }
            }
            archiveStream.Position = 0;
            file.Name    = "RandomZip";
            file.Content = archiveStream.ToArray();
        }
    
        return file;
    }
