    Microsoft.Office.Interop.Excel.Application xlobj = 
        new Microsoft.Office.Interop.Excel.Application();
    xlobj.Visible = true;
    xlobj.DisplayAlerts = false;
    Excel.Workbook w = xlobj.Workbooks.Add();
    Excel.Worksheet sh = w.Worksheets[1];
    int row = 1;
    DirectoryInfo dirSrc = new DirectoryInfo(@"C:\Users\Excel\Desktop\excel_files\");
    foreach (FileInfo ChildFile in dirSrc.GetFiles())
    {
        Excel.Workbook wb = xlobj.Workbooks.Open(ChildFile.FullName);
        Excel.Range r = wb.Worksheets[1].UsedRange;
        r.Copy();
        sh.Cells[row, 1].PasteSpecial(Excel.XlPasteType.xlPasteValues,
            Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone);
        if (row > 1)
            sh.Cells[row--, 1].EntireRow.Delete();
        row += r.Rows.Count;
        wb.Close();
    }
    w.SaveAs("C:\\Users\\Excel\\Desktop\\excel_files\\MainExcel.xlsx");
