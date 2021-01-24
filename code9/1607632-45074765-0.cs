    using (Stream stream = System.IO.File.OpenRead(tarPath))
    {
        var reader = ReaderFactory.Open(stream);
        while (reader.MoveToNextEntry())
        {
            if (!reader.Entry.IsDirectory)
            {
               reader.WriteEntryToDirectory(extractPath, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
            }
        }
    }
