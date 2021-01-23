    [Flags]
    public enum EntryInfoTypes
    {
        Directory = 1,
        File = 2,
        DirectoryOrFile = Directory | File
    }
    public static class ZipDirectoryExtensions
    {
        private static readonly char[] _pathSeparators =
            new[] { Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar };
        public static IEnumerable<ZipDirectoryInfo> EnumerateDirectories(
            this ZipArchive archive, string path)
        {
            return archive.EnumerateDirectories(path, SearchOption.TopDirectoryOnly);
        }
        public static IEnumerable<ZipDirectoryInfo> EnumerateDirectories(
            this ZipArchive archive, string path, SearchOption searchOption)
        {
            return archive.EnumerateEntryInfos(path, searchOption, EntryInfoTypes.Directory)
                .Cast<ZipDirectoryInfo>();
        }
        public static IEnumerable<ZipFileInfo> EnumerateFiles(
            this ZipArchive archive, string path)
        {
            return archive.EnumerateFiles(path, SearchOption.TopDirectoryOnly);
        }
        public static IEnumerable<ZipFileInfo> EnumerateFiles(
            this ZipArchive archive, string path, SearchOption searchOption)
        {
            return archive.EnumerateEntryInfos(path, searchOption, EntryInfoTypes.File)
                .Cast<ZipFileInfo>();
        }
        public static IEnumerable<ZipEntryInfo> EnumerateEntryInfos(
            this ZipArchive archive, string path, EntryInfoTypes entryInfoTypes)
        {
            return archive.EnumerateEntryInfos(
                path, SearchOption.TopDirectoryOnly, entryInfoTypes);
        }
        public static IEnumerable<ZipEntryInfo> EnumerateEntryInfos(this ZipArchive archive,
            string path, SearchOption searchOption, EntryInfoTypes entryInfoTypes)
        {
            // Normalize input path, by removing any path separator character from the
            // beginning, and ensuring one is present at the end. This will ensure that
            // the path variable format matches the format used in the archive and which
            // is also convenient for the implementation of the algorithm below.
            if (path.Length > 0)
            {
                if (_pathSeparators.Contains(path[0]))
                {
                    path = path.Substring(1);
                }
                if (!_pathSeparators.Contains(path[path.Length - 1]))
                {
                    path = path + Path.AltDirectorySeparatorChar;
                }
            }
            HashSet<string> found = new HashSet<string>();
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (path.Length > 0 && !entry.FullName.StartsWith(path))
                {
                    continue;
                }
                int nextSeparator = entry.FullName.IndexOfAny(_pathSeparators, path.Length);
                if (nextSeparator >= 0)
                {
                    string directoryName = entry.FullName.Substring(0, nextSeparator + 1);
                    if (found.Add(directoryName))
                    {
                        if (entryInfoTypes.HasFlag(EntryInfoTypes.Directory))
                        {
                            yield return new ZipDirectoryInfo(directoryName);
                        }
                        if (searchOption == SearchOption.AllDirectories)
                        {
                            foreach (ZipEntryInfo info in
                                archive.EnumerateEntryInfos(
                                    directoryName, searchOption, entryInfoTypes))
                            {
                                yield return info;
                            }
                        }
                    }
                }
                else
                {
                    if (entryInfoTypes.HasFlag(EntryInfoTypes.File))
                    {
                        yield return new ZipFileInfo(entry.FullName);
                    }
                }
            }
        }
    }
    public class ZipEntryInfo
    {
        public string Name { get; }
        public ZipEntryInfo(string name)
        {
            Name = name;
        }
    }
    public class ZipDirectoryInfo : ZipEntryInfo
    {
        public ZipDirectoryInfo(string name) : base(name) { }
    }
    public class ZipFileInfo : ZipEntryInfo
    {
        public ZipFileInfo(string name) : base(name) { }
    }
