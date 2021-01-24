    using (var archive = ZipFile.OpenRead(filePathDir + "/" + filename))
    {
        var totalProgress = archive.Entries.Count;
        foreach (var entry in archive.Entries)
        {
            entry.ExtractToFile(destinationFileName); // specify the output path of thi entry
            // update progess there
        }
    }
