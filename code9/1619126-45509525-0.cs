    public static class DirectoryFindFile
    {
        public static IEnumerable<FileInfo> GetFilesBypartialName(this DirectoryInfo dirInfo, params string[] partialFilenames)
        {
            if (partialFilenames == null)
                throw new ArgumentNullException("partialFilenames");
            var lstpartialFilenames = new HashSet<string>(partialFilenames, StringComparer.OrdinalIgnoreCase);
            return dirInfo.EnumerateFiles()
                .Where(f => lstpartialFilenames.Contains(f.Name));
        }
        public static IEnumerable<FileInfo> GetFilesBypartialFilenamesAllDir(this DirectoryInfo dirInfo, params string[] partialFilenames)
        {
            if (partialFilenames == null)
                throw new ArgumentNullException("partialFilenames");
            var lstpartialFilenames = new HashSet<string>(partialFilenames, StringComparer.OrdinalIgnoreCase);
            return dirInfo.EnumerateFiles("*.*", SearchOption.AllDirectories)
                           .Where(f => lstpartialFilenames.Contains(f.Name));
        }
    }
