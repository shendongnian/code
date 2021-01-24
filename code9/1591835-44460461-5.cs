    public void ZipFolder()
    {
        string strStartPath = @"PATH TO FILES TO PUT IN ZIP FILE";
        string strZipPath = @"PATH TO ZIP FILE";
        if (File.Exists(strZipPath))
            File.Delete(strZipPath);
            
        using (ZipArchive archive = ZipFile.Open(strZipPath, ZipArchiveMode.Create))
        {
            foreach (FileInfo file in RecurseDirectory(strStartPath))
            {
                if (!(file.FullName.EndsWith(".TIF", StringComparison.OrdinalIgnoreCase)))
                {
                    var destination = Path.Combine(file.DirectoryName, file.Name).Substring(strStartPath.Length + 1);
                    archive.CreateEntryFromFile(Path.Combine(file.Directory.ToString(), file.Name), destination);
                }
            }
        }
    }
    public IEnumerable<FileInfo> RecurseDirectory(string path, List<FileInfo> currentData = null)
    {
        if (currentData == null)
            currentData = new List<FileInfo>();   
        var directory = new DirectoryInfo(path);
        foreach (var file in directory.GetFiles())
            currentData.Add(file);
        foreach (var d in directory.GetDirectories())
            RecurseDirectory(d.FullName, currentData);
        return currentData;
    }
