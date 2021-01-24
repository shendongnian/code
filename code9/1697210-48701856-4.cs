    public async Task LoadRouteImageAsync(string archiveName, string entryName)
    {
        RouteImage = await LoadImageAsync(archiveName, entryName);
    }
    private Task<BitmapImage> LoadImageAsync(string archiveName, string entryName)
    {
        return Task.Run(() =>
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
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = memoryStream;
                        bitmap.EndInit();
                        bitmap.Freeze(); // necessary for loading in Task thread
                    }
                }
            }
            return bitmap;
        });
    }
