    // Load INI file.
    IniFile ini = new IniFile();
    ini.Load("Sample.ini");
    
    // Get INI values.
    string header = ini.Sections["SampleSection"].Keys["ColumnHeaderValue"].Value;
    string search = ini.Sections["SampleSection"].Keys["SearchTextValue"].Value;
    string j = ini.Sections["SampleSection"].Keys["JColumnValue"].Value;
    
    // Load XLSX file.
    ExcelFile excel = ExcelFile.Load("Sample.xlsx");
    ExcelWorksheet sheet = excel.Worksheets[0];
    
    // Find column header value in first row.
    ExcelColumn searchColumn = sheet.Rows[0].Cells
        .First(cell => cell.ValueType == CellValueType.String && cell.StringValue == header)
        .Column;
    
    // Find search value in column.
    int r, c;
    searchColumn.Cells.FindText(search, false, false, out r, out c);
    ExcelCell searchCell = sheet.Cells[r, c];
    
    // Get cell from column "J" that is in the same row as cell that has search text.
    ExcelCell jCell = sheet.Cells[r, ExcelColumnCollection.ColumnNameToIndex("J")];
    // Set cell value.
    jCell.Value = j;
    
    // Save XLSX file.
    excel.Save("Sample.xlsx");
