        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                Console.WriteLine(entry.FullName);
                //entry.ExtractToFile(Path.Combine(destFolder, entry.FullName));
            }
        } 
