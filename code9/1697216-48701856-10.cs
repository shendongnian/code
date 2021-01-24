    public async Task LoadImageAsync(string archiveName, string entryName)
    {
        RouteImage = await Task.Run(() => LoadImage(archiveName, entryName));
    }
    private BitmapImage LoadImage(string archiveName, string entryName)
    {
        BitmapImage bitmap = null;
        using (var archive = ZipFile.OpenRead(archiveName))
        {
            var entry = archive.GetEntry(entryName);
            if (entry != null)
            {
                using (var zipStream = entry.Open())
                using (var memoryStream = new MemoryStream())
                {
                    zipStream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = memoryStream;
                    bitmap.EndInit();
                    bitmap.Freeze(); // necessary when loaded in non-UI thread
                }
            }
        }
        return bitmap;
    }
