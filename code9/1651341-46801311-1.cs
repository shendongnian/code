    private string FormatCSV(string str)
    {
        str = str.Replace("\"", "\"\"");
        return String.Format("\"{0}\"", str);
    }
