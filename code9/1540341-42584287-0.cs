        public IEnumerable<T> Find<T>(DirectoryInfo workingDirectory, 
                                       string searchPattern, 
                                       bool recursive = false) 
                                       where T : FileSystemInfo
        {
            var results = workingDirectory.EnumerateFileSystemInfos(searchPattern,
                recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            return results.OfType<T>();
        }
