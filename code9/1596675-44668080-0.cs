    public IListFileItem[] GetFilesInDirectory()
    {
        var directory = GetFileShareDirectory();
        IEnumerable<IListFileItem> allFilesInDirectory = directory.ListFilesAndDirectories();
        List<IListFileItem> allFiles = new List<IListFileItem>();
    
        foreach (var file in allFilesInDirectory)
        {
            string[] fileType = file.GetType().ToString().Split('.');
            string type = fileType[fileType.Length - 1];
            if (type == "CloudFile")
            {
                allFiles.Add(file);
            }
        }
        return allFiles.ToArray();
    }
