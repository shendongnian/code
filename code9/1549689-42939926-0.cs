    Microsoft.Office.Interop.Excel.Application xls = new Microsoft.Office.Interop.Excel.Application()
    Workbook wb = xls.Application.Workbooks.Open(fileInfo.Stream);
    /* edit document here */
    wb.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault); //saves your changes to the local drive location you specified
    wb.Close();
