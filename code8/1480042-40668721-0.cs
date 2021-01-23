    var addIn = Globals.ThisAddIn;
    Excel.Range range = addIn.Application.Selection;
    Excel.Workbook wb = addIn.Application.Workbooks.Add();
    Excel.Worksheet ws = wb.Worksheets[1];
    range.Copy();
    ws.get_Range("A1").PasteSpecial(Excel.XlPasteType.xlPasteValuesAndNumberFormats);
    addIn.Application.DisplayAlerts = false;
    wb.SaveAs(Path.Combine(_Outputdir, string.Format("{0}.csv", TableName)),
        Excel.XlFileFormat.xlCSV);
    wb.Close();
    addIn.Application.DisplayAlerts = true;
    string newFile = Commons.Compress(_Outputdir, string.Format("{0}.csv", TableName));
