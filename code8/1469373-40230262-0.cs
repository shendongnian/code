        foreach (var table in sheet.ListObjects)
        {
            Microsoft.Office.Interop.Excel.ListObject tempObj = table;
            Microsoft.Office.Interop.Excel.Range tempRange = table.Range;
            tempRange.ClearContents();        
        }
