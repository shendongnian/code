    public DataTable ReadFileContent(string filePath)
    {
        var rowStart = 7;
        var columnStart = 1;
        var existingFile = new FileInfo(filePath);
        using (var package = new ExcelPackage(existingFile))
        {
            var worksheet = package.Workbook.Worksheets["BOP"];
            var dt = new DataTable();
            var composedName = String.Empty;
            var stringBuilder = new StringBuilder();
            if (package.Workbook.Worksheets["CollaborationContext"].SelectedRange["B6"].Value.Equals("object_type"))
            {
                dt.TableName = package.Workbook.Worksheets["CollaborationContext"].SelectedRange["C9"].Value + " " +
                               package.Workbook.Worksheets["CollaborationContext"].SelectedRange["D9"].Value + " " +
                               package.Workbook.Worksheets["CollaborationContext"].SelectedRange["E9"].Value;
            }
            dt.TableName = package.Workbook.Worksheets["CollaborationContext"].SelectedRange["B9"].Value + " " +
                           package.Workbook.Worksheets["CollaborationContext"].SelectedRange["C9"].Value + " " +
                           package.Workbook.Worksheets["CollaborationContext"].SelectedRange["D9"].Value;
            for (var col = columnStart; col <= worksheet.Dimension.End.Column - 1; col++)
                dt.Columns.Add(worksheet.Cells[6, col].Value.ToString());
            // Place data into DataTable
            for (int row = rowStart; row <= worksheet.Dimension.End.Row; row++)
            {
                var dr = dt.NewRow();
                var x = 0;
                for (var col = columnStart; col <= worksheet.Dimension.End.Column - 1; col++)
                {
                    dr[x++] = worksheet.Cells[row, col].Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
