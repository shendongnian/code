    public static IEnumerable<string> DecompressToEntriesTextContext(byte[] input)
    {
        var zipEntriesContext = new List<string>();
        using (var compressedStream = new MemoryStream(input))
        using (var zip = new ZipArchive(compressedStream, ZipArchiveMode.Read))
        {
            foreach(var entry in zip.Entries)
            {
                using (var entryStream = entry.Open())
                using (var memoryEntryStream = new MemoryStream())
                using (var reader = new StreamReader(memoryEntryStream))
                {
                   entryStream.CopyTo(memoryEntryStream);
                   memoryEntryStream.Position = 0;
                   zipEntriesContext.Add(reader.ReadToEnd());
                }
            }
        }
        return zipEntriesContext;
    }
