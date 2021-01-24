    private string FormatCSV(string str)
    {
        str = (str ?? "").Replace(this.Delimiter, "\"" + this.Delimiter + "\"");
        str = str.Replace(this.LineBreak, "\"" + this.LineBreak + "\"");
        str = str.Replace("\"", "\"\"");
        return String.Format("\"{0}\"", str);
    }
