        public void AddDirectory(string zipPath, string entryName)
        {
            entryName = entryName.Trim().Replace('\\', '/');
            if (entryName.Right(1) != "/")
                entryName += "/";
            using (ZipArchive zArchive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
                zArchive.CreateEntry(entryName);
        }
