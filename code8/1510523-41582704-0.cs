    string filePath = "C:\\Users\\ussatdafa\\Desktop\\Work\\Projects\\test.xlsx";
    Microsoft.Office.Interop.Excel.Application excelApp =
        new Microsoft.Office.Interop.Excel.Application();
    if (excelApp == null)
    {
        MessageBox.Show("Excel has not been properly installed");
    }
    else
    {
        excelApp.Visible = true;
        Workbook wb = excelApp.Workbooks.Open(filePath, 0, false, 5, "", "", false,
            XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        Worksheet ws = wb.Sheets[1];
        wb.Names.Item("gv_epxsize").RefersToRange.Value = "101";
    }
