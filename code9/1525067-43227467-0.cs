    IXLWorksheet sheet = wb.Worksheets.Add("Sheet1");
    sheet.Cell(1, 1).InsertTable(dt);
    foreach (var column in sheet.ColumnsUsed())
    {
       string columnLetter = column.ColumnLetter();
       string rng = $"${columnLetter}2:columnLetter}sheet.RangeUsed().RowCount()}";
       sheet.Range(rng).DataType = some data type;
    }
