    public async Task<File> DownloadAndZipCarousel(string token) {
        //Get the model data from storage
        var images = await cache.GetAsync<IEnumerable<string>>(token);
        var client = CreateClient();
        var file = new File();
        var random = new Random();
        using (var archiveStream = new MemoryStream()) {
            using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, false)) {
                foreach (var uri in images) {
                    var imagename = $"Instagram{random.Next()}.jpg";
                    var archiveEntry = archive.CreateEntry(imagename, CompressionLevel.Optimal);
                    using (var entryStream = archiveEntry.Open()) {
                        using (var contentStream = await client.GetStreamAsync(uri)) {
                            await contentStream.CopyToAsync(entryStream);
                        }
                    }
                }
            }
            file.Name = "RandomZip"; //TODO: derive a better naming system
            file.Content = archiveStream.ToArray();
        }
        return file;
    }
