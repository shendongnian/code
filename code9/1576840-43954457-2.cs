    var wb = new XLWorkbook(@"<path>\test.xlsx", XLEventTracking.Disabled);
    var sheet = wb.Worksheet("Sheet1");
        
    for (int i = sheet.LastRowUsed().RowNumber() - 1; i >= 1; i--)
    {
        var row = sheet.Row(i);
        if (row.IsEmpty())
        {
            row.Delete();
        }
    }
        	
    wb.Save();
