    private DataTable GetDataTableForSingleRetrievalFile(string fileLoc)
    {
        DataTable retVal = GetBlankDTForRetrievals();
        string[] lines = System.IO.File.ReadAllLines(fileLoc);
        foreach(string line in lines.Where(l => l.Length > 94).Where((l) => l.StartsWith(" ")))
        {
            DataRow rowToAdd = retVal.NewRow();
            rowToAdd["ObjectID"] = line.Substring(48, 15);
            rowToAdd["DateTimeStamp"] = line.Substring(1, 17);
            rowToAdd["Username"] = line.Substring(32, 15);
            rowToAdd["DocClass"] = line.Substring(69, 20);
            rowToAdd["Func"] = line.Substring(90, 4);
            retVal.Rows.Add(rowToAdd);
        }
        return retVal;
    }
