    using (var archive = new ZipArchive(zipReadingStream))
    {
        var totalProgress = archive.Entries.Count;
        foreach (var entry in archive.Entries)
        {
            entry.ExtractToFile(destinationFileName); // specify the output path of thi entry
            // update progess there
        }
    }
