    protected void deleteYears(IXLWorksheet ws)
    {
        // Remove columns
        List<IXLColumn> deletecols = ws
            .Row(6)
            .CellsUsed(c => c.Value.ToString().ToUpper().StartsWith("XYZ"))
            .Select(c => c.WorksheetColumn()).ToList();
        foreach (IXLColumn x in deletecols)
        {
            x.Delete();
        }
    }
