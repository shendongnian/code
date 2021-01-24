    public static byte[] ZipFolderToMemory(string folder)
    {
        using (var stream = new MemoryStream())
        {
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Create))
            {
                foreach (var filePath in Directory.EnumerateFiles(folder))
                {
                    var entry = archive.CreateEntry(Path.GetFileName(filePath));
                    using (var zipEntry = entry.Open())
                    using (var file = new FileStream(filePath, FileMode.Open))
                    {
                        file.CopyTo(zipEntry);
                    }
                }
            }
            return stream.ToArray();
        }
    }
