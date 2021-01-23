    long totalBytesToDownload = 0;
    List<FileInfo> files;
    private void getTotalBytes(IEnumerable<string> urls)
    {
        files = new List<FileInfo>(urls.Count());
        foreach(string url in urls)
        {
            files.Add(new FileInfo(url));
        }
        files.ForEach(file => totalBytesToDownload += file.Length);
    }
