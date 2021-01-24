    private bool ParseContent(string filePath)
    {
        if (string.IsNullOrEmpty(FilePath) || !File.Exists(FilePath))
            return false;
        string logEntryDateTimeTemp = string.Empty;
        foreach(string line in File.ReadLines(filePath))
        {
            ProcessLine(line, ref logEntryDateTimeTemp);
        }
        return true;
    }
