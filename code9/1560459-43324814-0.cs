    public enum Readers
    {
        AdobeReader = 0,
        FoxitReader = 1
    }
    public Dictionary<int, string> PDFReaders = new Dictionary<int, string>()
    {
        { 0,"AcroExch.Document.DC" },
        { 1, "FoxitReader.Document" }
    };
    public void SetPDFDefault(Readers program)
    {
        string nVal = PDFReaders[(int)program];
        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.pdf\UserChoice",
            "ProgId", nVal,RegistryValueKind.String);
    }
