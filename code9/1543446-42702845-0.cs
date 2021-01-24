    var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName + @"\Documents\Businessprocess\Excel-Templates\Tabelle_zum_BP.xlsx";
    var excel = (Excel.Application)new Excel.ApplicationClass() { Visible = true };
    var template = excel.Workbooks.Add(path);
    var worksheet = (Excel.Worksheet)template.Worksheets["__SHEET_NAME__"];
    var table = (Excel.Range)worksheet.Range["__RANGE__"];
    
    table.Copy();
    _wordDocument.Bookmarks["EPExcelFile"].Range.PasteExcelTable(false, true, false);
