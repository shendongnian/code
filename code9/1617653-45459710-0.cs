    string rootPath = "abc/pqr/";
    using (ZipFile zipFile = ZipFile.Read(@"abc.zip"))
    {
        foreach (ZipEntry entry in zipFile.Entries)
        {
            if (entry.FileName.StartsWith(rootPath) && entry.FileName.Length > rootPath.Length)
            {
                string path = Path.Combine(@"D:/folder_name", entry.FileName.Substring(rootPath.Length));
                if (entry.IsDirectory)
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                        entry.Extract(stream);
                }                
            }
        }
    }
