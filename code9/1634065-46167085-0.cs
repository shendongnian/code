    Excelx.Range range = xlWorksheet.Range["AN1", "AN50"];
    range.Copy();
    Excelx.Workbook nb = xlApp.Application.Workbooks.Add();
    Excelx.Worksheet ns = nb.Sheets[1];
    ns.get_Range("A1").PasteSpecial(Excelx.XlPasteType.xlPasteValuesAndNumberFormats);
    nb.Application.DisplayAlerts = false;
    nb.SaveAs("Range.txt", Excelx.XlFileFormat.xlTextWindows);
    nb.Close();
    xlApp.Application.DisplayAlerts = true;
