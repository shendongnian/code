    public bool IsMediaFile(string fileNameWithExtension)
    {
        return fileNameWithExtension.EndsWith(".mp3")
               || fileNameWithExtension.EndsWith(".wmv")
               || fileNameWithExtension.EndsWith(".avi");
    }
    public Task<IEnumerable<string>> GetMediaFilesInDirectory(string path)
    {
        return Task.Factory.StartNew<IEnumerable<string>>(() =>
        {
            var random = new Random();
            var originalPathsArray = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(IsMediaFile).ToArray();
            return originalPathsArray.OrderBy(e => random.Next()).ToArray();
        });
    }
