    public static bool HasDuplicates(string path)
    {
        List<object> allObjects = new List<object>();
        using (ExcelPackage excel = new ExcelPackage(new FileInfo(path)))
        {
            // Go through all sheets
            foreach (var sheet in excel.Workbook.Worksheets)
            {
                // Go through all cells
                foreach (var cell in sheet.Cells)
                {
                    // Ignore null cells
                    if(cell.Value != null)
                    {
                        if (allObjects.Contains(cell.Value))
                            return true;
                        allObjects.Add(cell.Value);
                    }
                }
            }
            return false;
        }
    }
