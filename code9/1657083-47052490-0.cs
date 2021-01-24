    using (ExcelPackage excel = new ExcelPackage(file))
    {
        ExcelWorksheet ws;
        DataTable dt = new DataTable();
        // Get the worksheet
        ws = excel.Workbook.Worksheets["Chart"];
        // Create as many columns as there are rows
        for (int i = 0; i < ws.Dimension.End.Row; i++) {
            dt.Columns.Add(i.ToString());
        }
        // Go through each column and create a new row of data
        for (int i = 1; i <= ws.Dimension.End.Column; i++) {
            var row = dt.NewRow();
            for (int j = 1; j <= ws.Dimension.End.Row; j++) {
                row[j-1] = ws.Cells[j, i].Value;
            }
            dt.Rows.Add(row);
        }
    }
