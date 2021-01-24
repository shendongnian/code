    public DateTime? GetLastWriteTimeOfDirectory(string path)
    {
        return GetLatestFile(new DirectoryInfo(path))?.LastWriteTime;
    }
    private FileInfo GetLatestFile(DirectoryInfo directory)
    {
        if (!directory.Exists)
        {
            throw new Exception($"Directory {directory.FullName} does not exist.");
        }
        return directory.GetFiles()
                .Union(directory.GetDirectories().Select(d => GetLatestFile(d)))
                .OrderByDescending(f => (f == null ? DateTime.MinValue : f.LastWriteTime))
                .FirstOrDefault();
        }
    }
