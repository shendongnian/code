    public async Task<Models.Models.File> DownloadAndZipCarousel(IEnumerable<Image> images, string baseServerPath) {
      ...
      using (var archiveStream = new MemoryStream()) {
        using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, false)) {
          ...
        }
      }
      file.Name    = "RandomZip";
      file.Content = archiveStream.ToArray();
      return file;
    }
