    public bool IsChecked { get; set; }
    public Store(string id, string strName, string isChecked, string strImportFile)
    {
        sID = id;
        sName = strName;
        // It is better to do the cast outside the constructor to avoid any exception within
        IsChecked = Convert.ToBoolean(isChecked);
        sImportFile = strImportFile;
    }
