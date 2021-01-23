    private string _folderName;
    public string FolderName
    {
        get { return _folderName.TrimIfNotNull(); }
        set { _folderName = value.TrimIfNotNull(); }
    }
