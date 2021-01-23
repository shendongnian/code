    using (var stream = await (await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\test.7z")).OpenStreamForReadAsync())
    {
        using (var archive = SharpCompress.Archives.SevenZip.SevenZipArchive.Open(stream))
        {
            var entry = archive.Entries.First();
            using (var entryStream = entry.OpenEntryStream())
            {
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(entry.Key, CreationCollisionOption.OpenIfExists);
                using (var fileStream = await file.OpenStreamForWriteAsync())
                {
                    entryStream.CopyTo(fileStream);
                }
            }
        }
    }
