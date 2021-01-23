    public static DataTable ImportExcelDocument(string filename)
    {
        DataTable MethodResult = null;
        DataTable dt = new DataTable();
        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;
        // Add the columns
        Dictionary<string, int> Columns = new Dictionary<string, int>();
        for (int i = 0; i < workSheet.UsedRange.Columns.Count; i++)
        {
            string ColumnHeading = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[1, i + 1]).Value2);
            if (!String.IsNullOrWhiteSpace(ColumnHeading) && !dt.Columns.Contains(ColumnHeading))
            {
                Columns.Add(ColumnHeading, i + 1);
                dt.Columns.Add(ColumnHeading);
            }
        }
        // Add the rows
        int RowNumber = 2;
        for (int i = 0; i < workSheet.UsedRange.Rows.Count; i++)
        {
            try
            {
                RowNumber = i + 2;
                int ColumnCount = 0;
                DataRow Row = dt.NewRow();
                bool RowHasContent = false;
                foreach (KeyValuePair<string, int> kvp in Columns)
                {
                    string CellContent = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[RowNumber, kvp.Value]).Value2);
                    Row[ColumnCount] = CellContent;
                    ColumnCount++;
                    if (!string.IsNullOrWhiteSpace(CellContent))
                    {
                        RowHasContent = true;
                    }
                }
                if (RowHasContent)
                {
                    dt.Rows.Add(Row); ;
                }
            }
            catch
            {
            }
        }
        workBook.Close();
        MethodResult = dt;
        return MethodResult;
    }
