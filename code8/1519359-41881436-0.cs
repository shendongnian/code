    using (var ms = new MemoryStream())
    {
        using (var newArchive = new ZipArchive(ms, ZipArchiveMode.Create, true))
        {
            foreach (var uncompressedEntry in entries)
            {
                var newEntry = newArchive.CreateEntry(uncompressedEntry.Key, newCompressionLevel);
                using (var entryStream = newEntry.Open())
                using (var writer = new BinaryWriter(entryStream, Encoding.UTF8))
                {
                    writer.Write(uncompressedEntry.Value);
                }
            }
        }
        return ms.ToArray();
    }
