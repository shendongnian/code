    public bool IsChecked { get; set; }
    public Store(string id, string strName, string isChecked, string strImportFile)
    {
        sID = id;
        sName = strName;
        IsChecked = isChecked == "1";
        sImportFile = strImportFile;
    }
