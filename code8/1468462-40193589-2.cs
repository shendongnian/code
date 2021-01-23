    static bool AddDirectory(this ZipArchive archive, int rootLength, string directory)
    {
        bool hasFiles = false;
        foreach (var entry in Directory.GetFileSystemEntries(directory))
        {
            string relativePath = entry.Substring(rootLength);
            if (Directory.Exists(entry))
            {
                if (!archive.AddDirectory(rootLength, entry))
                {
                    archive.CreateEntry(relativePath + "/");
                }
            }
            else
            {
                archive.CreateEntryFromFile(entry, relativePath);
                hasFiles = true;
            }
        }
        return hasFiles;
    }
    public static void AddDirectoryWithoutRoot(this ZipArchive archive, string directory)
    {
        int pathRootLength = (directory.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar).Length;
        archive.AddDirectory(pathRootLength, directory);
        archive.CreateEntry("/");
    }
