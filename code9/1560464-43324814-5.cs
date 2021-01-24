    public enum Readers
    {
        AdobeReader = 0,
        FoxitReader = 1
    }
    Dictionary<int, string> _PDFReaders = new Dictionary<int, string>()
    {
        { 0,"AcroExch.Document.DC" },
        { 1, "FoxitReader.Document" }
    };
    public void SetPDFDefault(Readers program)
    {
        string nVal = _PDFReaders[(int)program];
        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.pdf\UserChoice",
            "ProgId", nVal,RegistryValueKind.String);
    }
