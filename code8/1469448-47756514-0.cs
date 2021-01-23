    var oXL = new Microsoft.Office.Interop.Excel.Application();
    oXL.Visible = false;
    
    Workbook Wbook = oXL.Workbooks.Open(txtFileName.Text, ReadOnly: true, Password: "password");
    
    var sheet = Wbook.Worksheets[1];
    
    foreach (Range row in sheet.UsedRange.Rows)
    {
        var firstName = sheet.Cells[row.Row, 1].Value2,
        var lastName = sheet.Cells[row.Row, 2].Value2
    }
