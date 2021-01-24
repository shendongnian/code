    public FileProcessor()
    {
        _fileDict = new Dictionary<string, FileInfo>();
        _emirdb = new EMIRDB();
    }
    public FileProcessor()
    {
        string replacenull = File.ReadAllText ("EMIR_VU_E_");
        replacenull = replacenull.Replace("null", "");
        File.WriteAllText("EMIR_VU_E_", replacenull);
    }
